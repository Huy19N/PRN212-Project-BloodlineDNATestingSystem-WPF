using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class VerifyEmailDAO
    {
        private readonly GeneCareContext _context;
        public VerifyEmailDAO()
        {
            _context = new GeneCareContext();
        }
        public VerifyEmailDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<VerifyEmail?> GetVerifyEmailByIdAsync(int key)
        {
            try
            {
                return await _context.VerifyEmails.FindAsync(key);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the verify email.", ex);
            }
        }

        public async Task<List<VerifyEmail>> GetAllVerifyEmailAsync()
        {
            try
            {
                return await _context.VerifyEmails.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all users.", ex);
            }
        }

        public async Task<VerifyEmail> CreateVerifyEmailAsync(VerifyEmail verifyEmail)
        {
            try
            {
                _context.VerifyEmails.Add(verifyEmail);
                await _context.SaveChangesAsync();
                return verifyEmail;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the verify email.", ex);
            }
        }

        public async Task<VerifyEmail> UpdateVerifyEmailAsync(VerifyEmail verifyEmail)
        {
            try
            {
                _context.Entry(verifyEmail).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return verifyEmail;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the verify email.", ex);
            }
        }

        public async Task<bool> DeleteVerifyEmailAsync(int key)
        {
            try
            {
                var verifyEmail = await _context.VerifyEmails.FindAsync(key);
                if (verifyEmail == null)
                {
                    return false; // Verify email not found
                }
                _context.VerifyEmails.Remove(verifyEmail);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the verify email.", ex);
            }
        }
    }
}
