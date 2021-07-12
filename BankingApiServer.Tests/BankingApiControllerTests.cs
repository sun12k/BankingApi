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
    }
}