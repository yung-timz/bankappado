using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankappado.Models
{
    public class Account
    {
        public int AccountId {get; set;}
        public string AccountNumber {get;set;}
        public decimal Balance {get; set;}
        public int CustomerId {get; set;}
        public Customer Customer {get; set;}
        public AccountType AccountType {get; set;}
         public IList<Account> Accounts {get; set;} = new List<Account>();
    }
}