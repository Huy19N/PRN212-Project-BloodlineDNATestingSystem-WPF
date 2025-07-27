using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccessLayer
{
    public class UserDAO
    {
        GeneCarePrnContext context = new GeneCarePrnContext();

        public User Login(string email, string password)
        {
            return context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public async Task<ReturnData?> GetAndSearchUser(string? key, int numberRecordsEachPage, int currentPage)
        {
            var query = context.Users.Include(u => u.Role)
                                     .Where(u => u.UserId.ToString().Contains(key ?? "") ||
                                                 u.Email.Contains(key ?? "") ||
                                                 u.FullName.Contains(key ?? "") ||
                                                 u.Role.RoleName.Contains(key ?? "") ||
                                                 u.IdentifyId.Contains(key ?? ""));

            int totalRecords = await query.CountAsync();

            int maxPage = (int)Math.Ceiling((double)totalRecords / numberRecordsEachPage);

            var pagedData = await query.Skip((currentPage - 1) * numberRecordsEachPage)
                                       .Take(numberRecordsEachPage)
                                       .ToListAsync();
            return new ReturnData()
            {
                currentPage = currentPage,
                numberRecords = totalRecords,
                maxPage = maxPage,
                Data = pagedData
            };
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
