using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankappado.Models;

namespace bankappado.Interface.Repository
{
    public interface ICustomerRepository
    {
        Customer Add(Customer Customer);
        Customer Update(Customer Customer);
        Customer Get(int id);
        Customer GetCustomerByAccountNumber(string AccountNumber);
        void Delete(Customer Customer);
        IList<Customer> GetAll();
    }
}