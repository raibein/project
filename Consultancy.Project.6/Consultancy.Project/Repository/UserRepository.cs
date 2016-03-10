using Consultancy.Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultancy.Project.Repository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Login(string username, string password);
    }

    public class UserRepository : IUserRepository
    {
        public List<User> GetAll()
        {
            return new List<User>()
            {
                new User
                {
                    Id=1,
                    UserName="admin",
                    Password="admin",
                    Email="admin@gmail.com",
                    Status=true
                },
                new User
                {
                    Id=2,
                    UserName="user",
                    Password="user",
                    Email="user@gmail.com",
                    Status=false
                }
            };
        }

        public User Login(string username, string password)
        {
            var user = (from u in GetAll() where u.UserName==username && u.Password==password select u).ToList();

            if(user.Count > 0)
            {
                return user.Single();
            }
            return null;
        }
    }
}
