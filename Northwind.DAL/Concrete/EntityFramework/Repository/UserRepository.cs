using Microsoft.EntityFrameworkCore;
using Northwind.DAL.Abstract;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Concrete.EntityFramework.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
            
        }

        public User Login(User login)
        {
            return _dbset.SingleOrDefault(u => u.UserCode == login.UserCode && u.Password == login.Password);
        }

        public User Register(User register)
        {
            _context.Entry(register).State = EntityState.Added;
            _context.Add(register);
            _context.SaveChanges();

            return register;
        }
    }
}
