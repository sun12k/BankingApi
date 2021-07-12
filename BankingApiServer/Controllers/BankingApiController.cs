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
        private List<Account> accounts = new List<Account> { new Account
            {
                Id = 1,
                Name = "Arisha Barron",
                Balance = 100

            }, new Account
            {
                Id = 2,
                Name = "Branden Gibson",
                Balance = 100

            }, new Account
            {
                Id = 3,
                Name = "Rhonda Church",
                Balance = 100

            }, new Account
            {
                Id = 4,
                Name = "Georgina Hazel",
                Balance = 100

            }
            };

        public BankingApiController(ILogger<BankingApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Account> GetListOfAccounts()
        {
            return accounts;
            
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
        [HttpGet]
        public int Balance(int accountNumber)
        {
            //Validation
            if(accountNumber <= 0)
            {
                return 0;
            }

            //get the balance for the account
            try
            {
                if(accounts.Any(a=>a.Id == accountNumber))
                {
                    return accounts.FirstOrDefault(a => a.Id == accountNumber).Balance;
                }
            }
            catch (Exception ex) {
                _logger.LogError("Balance request was received for invalid account : " + ex.Message);
            }

            return 0;        
        }
    }
}
