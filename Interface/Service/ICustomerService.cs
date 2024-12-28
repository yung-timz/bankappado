using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankappado.Dto;

namespace bankappado.Interface.Service
{
    public interface ICustomerService
    {
        CustomerDto Create(CreateCustomerRequestModel model);
        CustomerDto Update(int id, UpdateCustomerRequestModel model);
        CustomerDto Get(int id);
        CustomerDto GetCustomerByAccountNumber(string AccountNumber);
        IList<CustomerDto> GetAll();
        void Delete(int id);
        CustomerDto Login(LoginCustomerRequestModel model);
    }
}