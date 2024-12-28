using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankappado.Models
{
    public class User
    {
        public int Id {get;set;}
        public Customer  Customer{get;set;}
        public string Email {get;set;}
        public string PassWord {get;set;}
        public int Pin {get;set;}
    }
}