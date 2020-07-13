using lab6.Core.Controllers;
using lab6.Core.Models;
using NUnit.Framework;

namespace lab6.Core.Tests
{
    class UnitTestCase
    {
        [Test]
        public void TestAuthenticationSuccess()
        {
            Assert.AreEqual(typeof(User), MainController.AuthenticationUser("admin", "1")?.GetType());
            Assert.AreEqual(typeof(User), MainController.AuthenticationUser("user", "1")?.GetType());
            Assert.AreEqual(typeof(User), MainController.AuthenticationUser("test@test.ru", "1")?.GetType());
        }

        [Test]
        public void TestAuthenticationWrong()
        {
            Assert.AreEqual(null, MainController.AuthenticationUser("Worng1", "111111"));
            Assert.AreEqual(null, MainController.AuthenticationUser("wrongwrongwrong", "aaaaa"));
            Assert.AreEqual(null, MainController.AuthenticationUser("WRONG", "aaaaa111111"));
            Assert.AreEqual(null, MainController.AuthenticationUser("123123", "AAAAAA111111"));

        }


    }
}