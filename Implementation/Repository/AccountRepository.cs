using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bankappado.AppContext;
using bankappado.Interface.Repository;
using bankappado.Models;

namespace bankappado.Implementation.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly Context _context;

        public AccountRepository()
        {
            _context = new Context();
        }
        public Account Add(Account account)
        {
             _context.Accounts.Add(account);
            _context.SaveChanges();
            return account;
        }

        public void Delete(Account account)
        {
           _context.Accounts.Remove(account);
            _context.SaveChanges();
        }

        public Account Get(int id)
        {
            return _context.Accounts.SingleOrDefault(a => a.AccountId == id);
        }

        public Account GetAccountNumber(string accountnumber)
        {
            return _context.Accounts.SingleOrDefault(a => a.AccountNumber == accountnumber);
        }

        public IList<Account> GetAll()
        {
           return _context.Accounts.ToList();
        }

        public Account Update(Account account)
        {
             _context.Accounts.Update(account);
            _context.SaveChanges();
            return account;
        }
    }
}