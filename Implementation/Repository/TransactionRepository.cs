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
    public class TransactionRepository : ITransactionRepository
    {
        private readonly Context _context;

        public TransactionRepository()
        {
            _context = new Context();
        }

        public Transaction Add(Transaction transaction)
        {
             _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return transaction;
        }

        public void Delete(Transaction transaction)
        {
           _context.Transactions.Remove(transaction);
            _context.SaveChanges();
        }

        public Transaction Get(int id)
        {
            return _context.Transactions.SingleOrDefault(a => a.TransactionId == id);
        }

        public IList<Transaction> GetAll()
        {
            return _context.Transactions.ToList();
        }

        public Transaction Update(Transaction transaction)
        {
           _context.Transactions.Update(transaction);
            _context.SaveChanges();
            return transaction;
        }
    }
}