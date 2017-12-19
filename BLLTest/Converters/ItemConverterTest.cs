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
    public class ItemConverterTest
    {
        IConverter<Item, ItemBO> converter;
        [SetUp]
        public void Setup()
        {
            converter = new ItemConverter();
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void ConvertBOToEntNull()
        {
            Item ent = converter.Convert((ItemBO)null);

            Assert.IsNull(ent);
        }

        [Test]
        public void ConvertBOToEntId()
        {
            var item = new ItemBO() { Id = 1 };
            Item bo = converter.Convert(item);

            Assert.AreEqual(bo.Id, 1);
        }
    }
}
