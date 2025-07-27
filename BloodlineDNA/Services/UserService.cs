using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;
using Repositories.Interface;

namespace Services
{
    public class UserService : Interface.IUserService
    {
        IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }
        public bool DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User Login(string email, string password)
        {
            return _userRepository.Login(email, password);
        }

        public User Register(User user)
        {
            return _userRepository.Register(user);
        }

        public bool UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
        public async Task<ReturnData?> GetAndSearchUser(string? key, int numberRecordsEachPage, int currentPage)
        {
            return await _userRepository.GetAndSearchUser(key, numberRecordsEachPage, currentPage);
        }
    }
}
