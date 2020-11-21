using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irfuni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            var accountController = new AccountController();
            
            var actualResult = accountController.ValidateEmail(email);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [
            Test,
            TestCase("abcdEFGH", false),
            TestCase("ABCD1234", false),
            TestCase("abcd1234", false),
            TestCase("Abcd123", false),
            TestCase("ABcd1234", true)
        ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            var accountController = new AccountController();

            var actualResult = accountController.ValidatePassword(password);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [
        Test,
        TestCase("irf@uni-corvinus.hu", "Abcd1234"),
        TestCase("irf@uni-corvinus.hu", "ABcd12345678")
        ]
        public void TestRegisterHappyPath(string email, string password)
        {
            var accountController = new AccountController();

            var actualResult = accountController.Register(email, password);

            Assert.AreEqual(email, actualResult.Email);
            Assert.AreEqual(password, actualResult.Password);
            Assert.AreNotEqual(Guid.Empty, actualResult.ID);
        }

        [Test,
        TestCase("irf@uni-corvinus.hu", "abcd1234"),
        TestCase("irfuni-corvinus.hu", "Abcd1234"),
        TestCase("irf@uni-corvinus", "Abcd1234"),
        TestCase("irf@uni-corvinus.hu", "Abcdefgh"),
        TestCase("irf@uni-corvinus.hu", "Abcd123"),
        TestCase("irf@uni-corvinus.hu", "ABCD1234")]
        public void TestRegisterValidateException(string emial, string password)
        {
            var accountController = new AccountController();

            try
            {
                var actualResult = accountController.Register(emial, password);
                Assert.Fail();
            }
            catch (Exception ex)
            {

                Assert.IsInstanceOf<ValidationException>(ex);
            }
        }
    }
}
