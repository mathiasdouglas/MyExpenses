﻿/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.InfrastructureTest
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using MyExpenses.Domain.Interfaces.Repositories;

    [TestClass]
    public class LabelRepositoryTest : InfrastructureTestBase
    {
        private ILabelRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _repository = GetAppService<ILabelRepository>();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _repository = null;
        }

        [TestMethod]
        public void InitAndFill()
        {
            var all = _repository.Get();

            Assert.IsTrue(all.Any());
        }
    }
}