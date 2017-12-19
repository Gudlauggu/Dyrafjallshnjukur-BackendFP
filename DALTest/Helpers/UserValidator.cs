using DAL.Entities;
using DAL.Helpers;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DALTest.Helpers
{
    [TestFixture]
    public class UserValidatorTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [TearDown]
        public void tearDown()
        {

        }

        [Test]
        public void TestUserNull()
        {
            var exception = Assert.Throws<ArgumentException>(
                                    () => new UserValidator(null));
            Assert.AreEqual("User cannot be null", exception.Message);
        }

        [Test]
        public void TestUserNameNull()
        {
            var user = new User() { Username = null };
            var exception = Assert.Throws<ArgumentException>(
                                    () => new UserValidator(user));
            Assert.AreEqual("Username cannot be null", exception.Message);

        }


        
        [TestCase("")]
        [TestCase("ABC")]
        [TestCase("ABCDE")]
        public void TestUserNameMin(string name)
        {
            var user = new User() { Username = name };
            var validator = new UserValidator(user);

            var exception = Assert.Throws<ArgumentException>(
                () => validator.ValidateUserName());
            Assert.AreEqual("Username to Short", exception.Message);


        }

        //21+ char test
        [TestCase("ABCDEFGHIJKskdkksaldd")]
        [TestCase("ABCDEFGHIJKskdkksaldABCDEFGHIJKskdkksaldd")]
        [TestCase("ABCDEFGHIJKskdkksaldksædsldasældksæaldkæfmlknvkfnmfskdæfaælsdkfldæsfksldæfmkalfdmklæsdmfskldf")]
        public void TestUserNameMax(string name)
        {
            var user = new User() { Username = name };
            var validator = new UserValidator(user);

            var exception = Assert.Throws<ArgumentException>(
                () => validator.ValidateUserName());
            Assert.AreEqual("Username to Long", exception.Message);


        }

        [TestCase("aaabdbb")]
        [TestCase("bfbbbddvv")]
        [TestCase("bfbbbdds")]
        public void TestUserNameContainsToManySameCharInARow(string name)
        {
            var user = new User() { Username = name };
            var validator = new UserValidator(user);

            var exception = Assert.Throws<ArgumentException>(
                () => validator.ValidateUserName());
            Assert.AreEqual("Username Can not contain same char 3 or more times in a row", exception.Message);

        }

        [TestCase(".ABCDEF.")]
        [TestCase("AB,CDEF,")]
        [TestCase("ABC/DEF/")]
        [TestCase("ABCD_EF_")]
        [TestCase("A(BCDEF(")]
        [TestCase("ABCD)EF)")]
        public void TestUserNameContainsSpecialChar(string name)
        {
            var user = new User() { Username = name };
            var validator = new UserValidator(user);

            var exception = Assert.Throws<ArgumentException>(
                () => validator.ValidateUserName());
            Assert.AreEqual("Username Cannot contain Special Chars like '.', ',', '/', '_', '(' and ')'", exception.Message);

        }
    }
}
