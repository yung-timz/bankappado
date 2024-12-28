using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankappado.Dto
{
    public class CustomerDto
    {
       public int Id {get; set;}
       public string FirstName {get; set;}
       public string LastName {get; set;}
       public string Email {get; set;}
       public int Pin {get; set;}
    }
    
    public class CreateCustomerRequestModel
    {
        public string FirstName {get; set;}
       public string LastName {get; set;}
       public string Email {get; set;}
       public int Pin {get; set;}
    }

    public class UpdateCustomerRequestModel
    {
        public string FirstName {get; set;}
       public string LastName {get; set;}
    }
    public class LoginCustomerRequestModel
    {
        public string Email {get; set;}
       public string Pin {get; set;}
    }

}