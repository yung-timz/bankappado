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
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;

        public AccountService(IAccountRepository accountRepository, ICustomerRepository customerRepository, IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
            _userRepository = userRepository;
        }

        public AccountResponseModel CheckBalance(string accountnumber, int pin)
        {
             var customer = _customerRepository.GetCustomerByAccountNumber(accountnumber);
            if(customer == null)
            {
                return new AccountResponseModel
                {
                    Message = "customer not found",
                    Success = false,
                };
            }
            if(customer.Pin != pin)
            {
                return new AccountResponseModel
                {
                    Message = "wrong pin",
                    Success = false,
                };
            }
            var account = _accountRepository.GetAccountNumber(accountnumber);
            if(account == null)
            {
                return new AccountResponseModel
                {
                    Message = "account not found",
                    Success = false,
                };
            }
            
            return  new AccountResponseModel
            {
                Balance = account.Balance,
                Message = "check sucessful, your current balance is {account.Balance}",
                Success = true,
            };
        }

        public AccountDto Create(CreateAccountRequestModel model ,int cusID)
        {
           var customer = _customerRepository.Get(1);
           if(customer.Equals(null)){return null;}
           Random random = new Random();
           var num = random.Next(000000000,999999999);
           var account = new Account()
           {
            Balance = 0.00M,
            CustomerId=customer.Id,
            AccountNumber= $"01{num}",
            AccountType = (AccountType)model.AccountType,
            
           };
           _accountRepository.Add(account);
           return new AccountDto()
           {
             FirstName = customer.FirstName,
             LastName = customer.LastName,
             AccountNumber = customer.AccountNumber,
             AccountType = account.AccountType.ToString(),
           };
        }


        public void Delete(int id)
        {
           var account = _accountRepository.Get(id);
            _accountRepository.Delete(account);
        }

        public AccountDto Get(int id)
        {
            var account = _accountRepository.Get(id);
            return new AccountDto
            {
                AccountNumber = account.AccountNumber 
            };
        }

        public IList<AccountDto> GetAll()
        {
            return _accountRepository.GetAll().Select( a => new AccountDto
            {
                AccountNumber = a.AccountNumber
            }).ToList();
        }

        public AccountDto Login(LoginAccountRequestModel model)
        {
            var user = _userRepository.Get(model.Email , model.PassWord);
            if(user != null)
            {
                return new AccountDto
                {
                    FirstName = user.Customer.FirstName,
                    LastName = user.Customer.LastName,
                    Email = user.Email
                }; 
            }
            return null;
        }

        public AccountDto Update(int id, UpdateAccountRequestModel model)
        {
            var account =_accountRepository.Get(id);
            account.AccountNumber = model.AccountNumber;
            account.AccountNumber = model.AccountNumber;
           var accountInfo =  _accountRepository.Update(account);
           return new AccountDto
           {
                AccountNumber = accountInfo.AccountNumber
           };
        }
    }
}