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
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;


        public TransactionService(ITransactionRepository transactionRepository, ICustomerRepository customerRepository, IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _transactionRepository = transactionRepository;
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }


        public TransactionDto Create(CreateTransactionRequestModel model)
        {
          throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TransactionResponseModel Deposit(string accountnumber, decimal amount, int pin)
        {
            var customer = _customerRepository.GetCustomerByAccountNumber(accountnumber);
            if(customer == null)
            {
                return new TransactionResponseModel
                {
                    Message = "customer not found",
                    Success = false,
                };
            }
            if(customer.Pin != pin)
            {
                return new TransactionResponseModel
                {
                    Message = "wrong pin",
                    Success = false,
                };
            }
            var account = _accountRepository.GetAccountNumber(accountnumber);
            if(account == null)
            {
                return new TransactionResponseModel
                {
                    Message = "account not found",
                    Success = false,
                };
            }
            account.Balance += amount;
            _accountRepository.Update(account);
            var transaction= new Transaction()
            {
                Description ="DEPOSIT",
                AccountId = account.AccountId,
                Amount = amount,
                TransactionDate = DateTime.Now,
                CustomerId = customer.Id,
                
            };
            return  new TransactionResponseModel
            {
                Message = $"deposited sucessful, your current balance is {account.Balance}",
                Success = true,
            };
        }

        public TransactionDto Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<TransactionDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public TransactionResponseModel Transfer(string accountnumber, decimal amount, int pin)
        {
            var customer = _customerRepository.GetCustomerByAccountNumber(accountnumber);
            if(customer == null)
            {
                return new TransactionResponseModel
                {
                    Message = "customer not found",
                    Success = false,
                };
            }
            if(customer.Pin != pin)
            {
                return new TransactionResponseModel
                {
                    Message = "wrong pin",
                    Success = false,
                };
            }
            var account = _accountRepository.GetAccountNumber(accountnumber);
            if(account == null)
            {
                return new TransactionResponseModel
                {
                    Message = "account not found",
                    Success = false,
                };
            }
            account.Balance += amount;
            _accountRepository.Update(account);
            var transaction= new Transaction()
            {
                Description ="Transfer",
                AccountId = account.AccountId,
                Amount = amount,
                TransactionDate = DateTime.Now,
                CustomerId = customer.Id,
                
            };
            return  new TransactionResponseModel
            {
                Message = "transfer sucessful, your current balance is {account.Balance}",
                Success = true,
            };
        }
        public TransactionDto Update(int id, UpdateTransactionRequestModel model)
        {
            throw new NotImplementedException();
        }

        public TransactionResponseModel Withdraw(string accountnumber, decimal amount, int pin)
        {
            var customer = _customerRepository.GetCustomerByAccountNumber(accountnumber);
            if(customer == null)
            {
                return new TransactionResponseModel
                {
                    Message = "customer not found",
                    Success = false,
                };
            }
            if(customer.Pin != pin)
            {
                return new TransactionResponseModel
                {
                    Message = "wrong pin",
                    Success = false,
                };
            }
            var account = _accountRepository.GetAccountNumber(accountnumber);
            if(account == null)
            {
                return new TransactionResponseModel
                {
                    Message = "account not found",
                    Success = false,
                };
            }
            account.Balance -= amount;
            _accountRepository.Update(account);
            var transaction= new Transaction()
            {
                Description ="WITHDRAW",
                AccountId = account.AccountId,
                Amount = amount,
                TransactionDate = DateTime.Now,
                CustomerId = customer.Id,
                
            };
            return  new TransactionResponseModel
            {
                Message = $"withdraw sucessful, your current balance is {account.Balance}",
                Success = false,
            };
        }

        
    }
}