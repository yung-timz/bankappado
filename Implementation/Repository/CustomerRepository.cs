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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository()
        {
            _context = new Context();
        }
        public Customer Add(Customer customer)
        {
             _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public Customer Get(int id)
        {
             return _context.Customers.SingleOrDefault(a => a.Id == id);
        }

        public Customer GetCustomerByAccountNumber(string accountnumber)
        {
            return _context.Customers.SingleOrDefault(a => a.AccountNumber == accountnumber);
        }

        public IList<Customer> GetAll()
        {
           return _context.Customers.ToList();
        }

        public Customer Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return customer;
        }

       
    }
}