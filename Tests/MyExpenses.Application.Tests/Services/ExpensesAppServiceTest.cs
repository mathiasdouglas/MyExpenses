﻿/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Tests.Services
{
    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Application.Tests.ModulesMock;
    using MyExpenses.Util.IoC;
    using MyExpenses.Util.Results;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ExpensesAppServiceTest
    {
        private const string NAME = "Expense1";
        private const string NEW_NAME = "NewName";
        private const long ID = 1;

        private readonly ExpenseDto _invalidDto = new ExpenseDto { Id = 10, Name = string.Empty };
        private readonly ExpenseDto _validDto = new ExpenseDto { Id = 10, Name = "tmp", Value = 1, Date = new DateTime() };

        private IExpensesAppService _appService;

        [SetUp]
        public void SetUp()
        {
            MyKernelService.Reset();
            MyKernelService.AddModule(new MyApplicationModuleMock());

            _appService = MyKernelService.GetInstance<IExpensesAppService>();
        }

        [Test]
        public void TestExpensesAppService_GetAllExpenses()
        {
            var dtos = _appService.GetAll();
            
            Assert.True(dtos.Any());
        }

        [Test]
        public void TestExpensesAppService_GetById_OK()
        {
            var dto = _appService.GetById(ID);

            Assert.IsNotNull(dto);
            Assert.IsTrue(dto.Name.Equals(NAME));
        }

        [Test]
        public void TestExpensesAppService_GetById_ErrorNotFind()
        {
            var dto = _appService.GetById(1000);

            Assert.IsNull(dto);
        }

        [Test]
        public void TestExpensesAppService_SaveExpense_OK()
        {
            var dto = _validDto;
            dto.Id = 0;
            dto.Name = NEW_NAME;

            var results = _appService.AddOrUpdate(dto);

            Assert.True(_appService.GetAll().Where(x => x.Name == NEW_NAME).Any());
            Assert.True(results.Status == MyResultsStatus.Ok);
            Assert.True(results.Action == MyResultsAction.Creating);
        }

        [Test]
        public void TestExpensesAppService_SaveAndUpdateExpense_Error()
        {
            var results = _appService.AddOrUpdate(_invalidDto);

            Assert.True(results.Status == MyResultsStatus.Error);
        }

        [Test]
        public void TestExpensesAppService_RemoveExpense_OK()
        {
            var dto = _appService.GetById(ID);

            var results = _appService.Remove(dto);

            Assert.True(results.Status == MyResultsStatus.Ok);
        }

        [Test]
        public void TestExpensesAppService_RemoveExpense_Error()
        {
            var results = _appService.Remove(_invalidDto);

            Assert.True(results.Status == MyResultsStatus.Error);
        }
    }
}
