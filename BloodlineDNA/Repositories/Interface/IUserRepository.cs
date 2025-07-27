using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories.Interface
{
    public interface IUserRepository
    {
        public User Login(string email, string password);
        public User Register(User user);
        public List<User> GetAllUsers();
        public User GetUserById(int id);
        public bool UpdateUser(User user);
        public bool DeleteUser(int id);
        public User GetUserByEmail(string email);
        Task<ReturnData?> GetAndSearchUser(string? key, int numberRecordsEachPage, int currentPage);
    }
}
