using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoleDAO
    {
        private readonly GeneCareContext _context;
        public RoleDAO()
        {
            _context = new GeneCareContext();
        }
        public RoleDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<Role?> GetRoleByIdAsync(int roleId)
        {
            try
            {
                return await _context.Roles.FindAsync(roleId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the role.", ex);
            }
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            try
            {
                return await _context.Roles.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all role.", ex);
            }
        }

        public async Task<Role> CreateRoleAsync(Role role)
        {
            try
            {
                _context.Roles.Add(role);
                await _context.SaveChangesAsync();
                return role;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the role.", ex);
            }
        }

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            try
            {
                _context.Entry(role).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return role;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the role.", ex);
            }
        }

        public async Task<bool> DeleteRoleAsync(int roleId)
        {
            try
            {
                var role = await _context.Roles.FindAsync(roleId);
                if (role == null)
                {
                    return false; // Role not found
                }
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the role.", ex);
            }
        }
    }
}
