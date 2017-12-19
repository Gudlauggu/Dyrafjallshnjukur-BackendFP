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
    public class PubConverterTest
    {
        IConverter<Pub, PubBO> converter;
        [SetUp]
        public void Setup()
        {
            converter = new PubConverter();
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void ConvertBOToEntNull()
        {
            Pub ent = converter.Convert((PubBO)null);

            Assert.IsNull(ent);
        }

        [Test]
        public void ConvertBOToEntId()
        {
            var pub = new PubBO() { Id = 1 };
            Pub bo = converter.Convert(pub);

            Assert.AreEqual(bo.Id, 1);
        }
    }
}
