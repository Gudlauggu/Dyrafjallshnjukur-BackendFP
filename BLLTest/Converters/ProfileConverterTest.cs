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
    public class ProfileConverterTest
    {
        IConverter<Profile, ProfileBO> converter;
        [SetUp]
        public void Setup()
        {
            converter = new ProfileConverter();
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void ConvertBOToEntNull()
        {
            Profile ent = converter.Convert((ProfileBO)null);

            Assert.IsNull(ent);
        }

        [Test]
        public void ConvertBOToEntId()
        {
            var profile = new ProfileBO() { Id = 1 };
            Profile bo = converter.Convert(profile);

            Assert.AreEqual(bo.Id, 1);
        }
    }
}
