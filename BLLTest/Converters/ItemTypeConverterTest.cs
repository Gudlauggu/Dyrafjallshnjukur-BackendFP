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
    public class ItemTypeConverterTest
    {
        IConverter<ItemType, ItemTypeBO> converter;
        [SetUp]
        public void Setup()
        {
            converter = new ItemTypeConverter();
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void ConvertBOToEntNull()
        {
            ItemType ent = converter.Convert((ItemTypeBO)null);

            Assert.IsNull(ent);
        }

        [Test]
        public void ConvertBOToEntId()
        {
            var item = new ItemTypeBO() { Id = 1 };
            ItemType bo = converter.Convert(item);

            Assert.AreEqual(bo.Id, 1);
        }
    }
}
