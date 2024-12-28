using System;
using bankappado.Models;

namespace bankappado.Dto
{
    public class TransactionDto
    {
        public int TransactionId {get; set;}
        public DateTime TransactionDate {get; set;}
        public string Description {get; set;}
        public decimal Amount {get; set;}
        public int AccountId {get; set;}
        public Account Account {get; set;}
    }

    public class CreateTransactionRequestModel
    {
        
        public int Amount{get; set;}

    }

    public class UpdateTransactionRequestModel
    {

    }

    public class TransactionResponseModel
    {
        public TransactionDto Transaction{get; set;}
        public string Message {get; set;}
        public bool Success {get; set;}
    }
}