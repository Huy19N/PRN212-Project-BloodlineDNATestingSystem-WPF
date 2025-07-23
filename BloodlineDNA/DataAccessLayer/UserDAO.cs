using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class UserDAO
    {
        GeneCarePrnContext context = new GeneCarePrnContext();

        public User Login(string email, string password)
        {
            return context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public User Register(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public bool UpdateUser(User user)
        {
            context.Users.Update(user);
            return context.SaveChanges() > 0;
        }

        public bool DeleteUser(int id)
        {
            var user = context.Users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                context.Users.Remove(user);
                return context.SaveChanges() > 0;
            }
            return false;
        }

        public User GetUserByEmail(string email)
        {
            return context.Users.FirstOrDefault(u => u.Email == email);
        }

        
    }

}
