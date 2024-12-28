using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankappado.Models;

namespace bankappado.Interface.Repository
{
    public interface ITransactionRepository
    {
        Transaction Add(Transaction Transaction);
        Transaction Update(Transaction Transaction);
        Transaction Get(int id);
        void Delete(Transaction Transaction);
        IList<Transaction> GetAll();
    }
}