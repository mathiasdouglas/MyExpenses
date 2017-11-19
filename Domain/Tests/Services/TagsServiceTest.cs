﻿/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Tests.Services
{
    using MyExpenses.Application.Tests.ModulesMock;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Models;
    using MyExpenses.Domain.Services;
    using MyExpenses.Util.IoC;
    using MyExpenses.Util.Results;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class TagsServiceTest
    {
        private ITagsService _service;

        [SetUp]
        public void Setup()
        {
            MyKernelService.Init();
            MyKernelService.AddModule(new MyDomainModuleMock());

            _service = MyKernelService.GetInstance<TagsService>();
        }

        [Test]
        public void TestTagsServiceSaveAndUpdate()
        {
            Tag tag = _service.GetById(1);
            tag.Name = "NewName";

            MyResults results = _service.AddOrUpdate(tag);

            Assert.True(results.Type == MyResultsType.Ok);
            tag = _service.GetById(1);
            Assert.True(tag.Name == "NewName");
        }

        [Test]
        public void TestTagsServiceGet()
        {
            List<Tag> tags = _service.Get(x => x.Id == 1).ToList();

            Assert.True(tags.Any());
        }

        [Test]
        public void TestTagsServiceGetAll()
        {
            List<Tag> tags = _service.GetAll().ToList();

            Assert.True(tags.Any());
        }

        [Test]
        public void TestTagsServiceRemove()
        {
            Tag tag = _service.GetById(2);

            MyResults results = _service.Remove(tag);

            Assert.True(results.Type == MyResultsType.Ok);
            Assert.IsNull(_service.GetById(2));
        }
    }
}
