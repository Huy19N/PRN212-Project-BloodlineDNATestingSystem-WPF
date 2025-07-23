using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class UserRepository : Interface.IUserRepository
    {
        UserDAO userDAO = new UserDAO();
        public bool DeleteUser(int id)
        {
            return userDAO.DeleteUser(id);
        }

        public List<User> GetAllUsers()
        {
            return userDAO.GetAllUsers();
        }

        public User GetUserByEmail(string email)
        {
            return userDAO.GetUserByEmail(email);
        }

        public User GetUserById(int id)
        {
            return userDAO.GetUserById(id);
        }

        public User Login(string email, string password)
        {
            return userDAO.Login(email, password);
        }

        public User Register(User user)
        {
            return userDAO.Register(user);
        }

        public bool UpdateUser(User user)
        {
            return userDAO.UpdateUser(user);
        }
    }
}
