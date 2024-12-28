using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bankappado.AppContext;
using bankappado.Interface.Repository;
using bankappado.Models;

namespace bankappado.Implementation.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository()
        {
            _context = new Context();
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void AddAccount ()
        {
            var account = new Account{AccountNumber = "0675169939" };
            _context.Accounts.Add(account);
          
        }

        public IList<Account> AccountList()
        {
           return _context.Accounts.ToList();
        }

        public void Delete(User user)
        {
           _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User Get(int id)
        {
            return _context.Users.SingleOrDefault(a => a.Id == id);
        }

        public User Get(string email, string passWord)
        {
            return _context.Users.Include(a => a.Customer).SingleOrDefault(a => a.Email == email && a.PassWord == passWord);
        }

        public IList<User> GetAll()
        {
             return _context.Users.ToList();
        }

        public User Update(User user)
        {
             _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}