
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bankappado.AppContext;
using bankappado.Dto;
using bankappado.Interface.Repository;
using bankappado.Interface.Service;
using bankappado.Models;

namespace bankappado.Implementation.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;

        public CustomerService(ICustomerRepository customerRepository, IUserRepository userRepository)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
        }
        public CustomerDto Create(CreateCustomerRequestModel model)
        {
            var user = new User
            {
                Email = model.Email,
                Pin = model.Pin
            };
             _userRepository.Add(user);
             
            var customer = new Customer{
                FirstName=model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Pin = model.Pin,
                UserId = user.Id
            };
           var customerInfo = _customerRepository.Add(customer);
            return  new CustomerDto{
           
                FirstName = customerInfo.FirstName,
                LastName = customerInfo.LastName,
                Email = customerInfo.Email,
                Pin = customerInfo.Pin,
                Id = customerInfo.Id
            };
        }

        public void Delete(int id)
        {
            var customer = _customerRepository.Get(id);
            _customerRepository.Delete(customer);
        }

        public CustomerDto Get(int id)
        {
            var customer = _customerRepository.Get(id);
            return new CustomerDto
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email
            };
        }

        public CustomerDto GetCustomerByAccountNumber(string accountnumber)
        {
            var customer = _customerRepository.GetCustomerByAccountNumber(accountnumber);
            return new CustomerDto
            {
                FirstName = customer.FirstName ,
                LastName = customer.LastName
            };
        }

        public IList<CustomerDto> GetAll()
        {
              return _customerRepository.GetAll().Select( a => new CustomerDto
            {
                FirstName = a.FirstName,
                LastName = a.LastName,
                Email = a.Email
                
            }).ToList();
        }

        public CustomerDto Login(LoginCustomerRequestModel model)
        {
             var user = _userRepository.Get(model.Email , model.Pin);
            if(user != null)
            {
                return new CustomerDto
                {
                    FirstName = user.Customer.FirstName,
                    LastName = user.Customer.LastName,
                    Email = user.Email
                }; 
            }
            return null;
        }

        public CustomerDto Update(int id, UpdateCustomerRequestModel model)
        {
            var customer =_customerRepository.Get(id);
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
           var customerInfo =  _customerRepository.Update(customer);
           return new CustomerDto
           {
                FirstName = customerInfo.FirstName,
                LastName = customerInfo.LastName
                
           };
        }

    }
}