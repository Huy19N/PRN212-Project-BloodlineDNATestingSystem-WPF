using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LogLoginDAO
    {
        private readonly GeneCareContext _context;
        public LogLoginDAO()
        {
            _context = new GeneCareContext();
        }
        public LogLoginDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<LogLogin?> GetLogLoginByIdAsync(int logId)
        {
            try
            {
                return await _context.LogLogins.FindAsync(logId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the log login.", ex);
            }
        }

        public async Task<List<LogLogin>> GetAllLogLoginsAsync()
        {
            try
            {
                return await _context.LogLogins.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all log login.", ex);
            }
        }

        public async Task<LogLogin> CreateLogLoginAsync(LogLogin logLogin)
        {
            try
            {
                _context.LogLogins.Add(logLogin);
                await _context.SaveChangesAsync();
                return logLogin;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the log login.", ex);
            }
        }

        public async Task<LogLogin> UpdateLogLoginAsync(LogLogin logLogin)
        {
            try
            {
                _context.Entry(logLogin).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return logLogin;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the log login.", ex);
            }
        }

        public async Task<bool> DeleteLogLoginAsync(int logId)
        {
            try
            {
                var logLogin = await _context.LogLogins.FindAsync(logId);
                if (logLogin == null)
                {
                    return false; // Log login not found
                }
                _context.LogLogins.Remove(logLogin);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the log login.", ex);
            }
        }
    }
}
