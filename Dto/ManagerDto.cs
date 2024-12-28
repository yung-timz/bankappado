namespace myproject.Dto
{
    public class ManagerDto
    {
        public int Id {get; set;}
       public string FirstName {get; set;}
       public string LastName {get; set;}
       public string Email {get; set;}
       public string PassWord {get; set;}
    }

    public class CreateManagerRequestModel
    {
        public string FirstName {get; set;}
       public string LastName {get; set;}
       public string Email {get; set;}
       public string PassWord {get; set;}
    }

    public class ManagerUpdateRequestModel
    {
        public string FirstName {get; set;}
       public string LastName {get; set;}
    }
    public class LoginManagerRequestModel
    {
        public string Email {get; set;}
       public string PassWord {get; set;}
    }
}