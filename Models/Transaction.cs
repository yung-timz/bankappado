using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankappado.Models
{
    public class Transaction
    {
        public int TransactionId {get; set;}
        public DateTime TransactionDate {get; set;}
        public string Description {get; set;}
        public decimal Amount {get; set;}
        public int AccountId {get; set;}
        public Account Account {get; set;}
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        // public IList<Account> Accounts {get; set;} = new List<Account>();

        public IList<Transaction> Transactions {get; set;} = new List<Transaction>();

    }
}