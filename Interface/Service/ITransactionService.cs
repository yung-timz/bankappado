using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankappado.Dto;

namespace bankappado.Interface.Service
{
    public interface ITransactionService
    {
        TransactionDto Create(CreateTransactionRequestModel model);
        TransactionDto Update(int id, UpdateTransactionRequestModel model);
        TransactionDto Get(int id);
        IList<TransactionDto> GetAll();
        void Delete(int id);
        TransactionResponseModel Deposit(string accountnumber, decimal amount, int pin);
        TransactionResponseModel Withdraw(string accountnumber, decimal amount, int pin);
        TransactionResponseModel Transfer (string accountnumber, decimal amount, int pim);
        
       
    }
}