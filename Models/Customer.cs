using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankappado.Models
{
    public class Customer
    {
        public int Id {get;set;}
         public int UserId {get;set;}
         public User User {get;set;}
         public  string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public int Pin {get;set;}
        public string AccountNumber {get;set;}
    }
}