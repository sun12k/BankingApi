using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApiServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankingApiController : ControllerBase
    {
        private readonly ILogger<BankingApiController> _logger;

        public BankingApiController(ILogger<BankingApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Account> GetListOfAccounts()
        {
            return new List<Account> { new Account
            {
                Id = 1,
                Name = "Arisha Barron"
            }, new Account
            {
                Id = 2,
                Name = "Branden Gibson"
            }, new Account
            {
                Id = 3,
                Name = "Rhonda Church"
            }, new Account
            {
                Id = 4,
                Name = "Georgina Hazel"
            }
            };
            
        }
        [HttpPost]
        public bool CreateAcccount(string name, int initialDeposit)
        {
            //Validation
            if(string.IsNullOrEmpty(name) || initialDeposit <= 0)
            {
                return false;
            }

            var newAccount = new Account { Name = name, Balance = initialDeposit };
            //TODO:persist newAccount
            return true;
        }
        [HttpPost]
        public bool Transfer(int fromAccount, int toAccount, int transferAmount)
        {
            //Validation
            if (transferAmount <= 0)//todo: add accountNumber validation too
            {
                return false;
            }
            else
            {
                //todo: finish the persistance for transfer
                return true;
            }
        }
    }
}
