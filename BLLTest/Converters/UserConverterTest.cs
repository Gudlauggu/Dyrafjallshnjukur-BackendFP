using BLL.BusinessObjects;
using BLL.Converters;
using DAL.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLTest.Converters
{
    [TestFixture]
    public class UserConverterTest
    {
        IConverter<User, UserBO> converter;
        [SetUp]
        public void Setup()
        {
            converter = new UserConverter();
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void ConvertBOToEntNull()
        {
            User ent = converter.Convert((UserBO)null);

            Assert.IsNull(ent);
        }

        [Test]
        public void ConvertBOToEntId()
        {
            var user = new UserBO() { Id = 1 };
            User bo = converter.Convert(user);

            Assert.AreEqual(bo.Id, 1);
        }
    }
}
