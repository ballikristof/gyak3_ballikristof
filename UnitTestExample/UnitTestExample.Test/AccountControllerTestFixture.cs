using System;
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
    }
}
