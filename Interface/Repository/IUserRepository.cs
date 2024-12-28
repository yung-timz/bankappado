using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankappado.Models;

namespace bankappado.Interface.Repository
{
    public interface IUserRepository
    {
        User Add(User User);
        User Update(User User);
        User Get(int id);
        User Get(string email , string passWord);
        void Delete(User user);
        IList<User> GetAll();
        IList<Account> AccountList ();
    }
}