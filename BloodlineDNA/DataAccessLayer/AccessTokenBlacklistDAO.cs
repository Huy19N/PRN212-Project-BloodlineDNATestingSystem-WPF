using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AccessTokenBlacklistDAO
    {
        private readonly GeneCareContext _context;
        public AccessTokenBlacklistDAO()
        {
            _context = new GeneCareContext();
        }
        public AccessTokenBlacklistDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<AccessTokenBlacklist?> GetAccessTokenBlacklistByIdAsync(int jwtId)
        {
            try
            {
                return await _context.AccessTokenBlacklists.FindAsync(jwtId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the access token blacklist.", ex);
            }
        }

        public async Task<List<AccessTokenBlacklist>> GetAllAccessTokenBlacklistsAsync()
        {
            try
            {
                return await _context.AccessTokenBlacklists.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all access token blacklist.", ex);
            }
        }

        public async Task<AccessTokenBlacklist> CreateAccessTokenBlacklistAsync(AccessTokenBlacklist accessTokenBlacklist)
        {
            try
            {
                _context.AccessTokenBlacklists.Add(accessTokenBlacklist);
                await _context.SaveChangesAsync();
                return accessTokenBlacklist;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the access token blacklist.", ex);
            }
        }

        public async Task<AccessTokenBlacklist> UpdateAccessTokenBlacklistAsync(AccessTokenBlacklist accessTokenBlacklist)
        {
            try
            {
                _context.Entry(accessTokenBlacklist).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return accessTokenBlacklist;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the access token blacklist.", ex);
            }
        }

        public async Task<bool> DeleteAccessTokenBlacklistAsync(int jwtId)
        {
            try
            {
                var accessTokenBlacklist = await _context.AccessTokenBlacklists.FindAsync(jwtId);
                if (accessTokenBlacklist == null)
                {
                    return false; // Access token blacklist not found
                }
                _context.AccessTokenBlacklists.Remove(accessTokenBlacklist);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the access token blacklist.", ex);
            }
        }
    }
}
