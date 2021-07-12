using BankingApiServer.Controllers;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System.Linq;

namespace BankingApiServer.Tests
{
    public class Tests
    {
        private readonly ILogger<BankingApiController> _logger;

        [SetUp]
        public void Setup()
        { }
    

        [Test]
        public void GetListOfAccounts()
        {
            var controller = new BankingApiController(_logger);
            var accounts = controller.GetListOfAccounts();
            Assert.AreEqual(4, accounts.Count());
        }

        [Test]
        public void CreateAccount_ShouldFailForWrongValues()
        {
            var controller = new BankingApiController(_logger);
            var success = controller.CreateAcccount("", 9);
            Assert.IsFalse(success);

            success = controller.CreateAcccount("someName", 0);
            Assert.IsFalse(success);
        }
        [Test]
        public void CreateAccount_ShouldPassForGoodValues()
        {
            var controller = new BankingApiController(_logger);
            var success = controller.CreateAcccount("someName", 9);
            Assert.IsTrue(true);
        }
    }
}