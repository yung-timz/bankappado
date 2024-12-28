using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankappado.Models;

namespace bankappado.Interface.Repository
{
    public interface IAccountRepository
    {
        Account Add(Account Account);
        Account Update(Account Account);
        Account Get(int id);
        Account GetAccountNumber (string accountnumber);
        void Delete(Account Account);
        IList<Account> GetAll();
    }
}