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
    public class OrderConverterTest
    {
        IConverter<Order, OrderBO> converter;
        [SetUp]
        public void Setup()
        {
            converter = new OrderConverter();
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void ConvertBOToEntNull()
        {
            Order ent = converter.Convert((OrderBO)null);

            Assert.IsNull(ent);
        }

        [Test]
        public void ConvertBOToEntId()
        {
            var order = new OrderBO() { Id = 1 };
            Order bo = converter.Convert(order);

            Assert.AreEqual(bo.Id, 1);
        }
    }
}
