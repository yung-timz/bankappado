using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankappado.Dto
{
    public class AccountDto
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string PassWord {get; set;}
         public int AccountId {get; set;}
         public string AccountType {get;set;}
        public string AccountNumber {get;set;}
        public decimal Balance {get; set;}
        public IList<TransactionDto> Transactions {get; set;} = new List<TransactionDto>();
    }

    public class CreateAccountRequestModel
    {
       public int  AccountType {get; set;}
    }
    
    public class UpdateAccountRequestModel
    {
        public string AccountNumber {get;set;}
    }

     public class LoginAccountRequestModel
    {
        public string Email {get;set;}
        public string PassWord {get; set;}
    }

    public class AccountResponseModel
    {
       public string AccountNumber {get;set;}
        public decimal Balance {get; set;}
        public string Message {get; set;}
        public bool Success {get; set;}
    }

}