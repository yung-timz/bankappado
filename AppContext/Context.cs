using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bankappado.Models;

namespace bankappado.AppContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;port=3306;Database=bankappado;Uid=root;Pwd=1234");
        }
          public DbSet<Customer> Customers { get; set; }
          public DbSet<User> Users {get; set;}
          public DbSet<Transaction> Transactions {get; set;}
          public DbSet<Account> Accounts {get; set;}
    }
}