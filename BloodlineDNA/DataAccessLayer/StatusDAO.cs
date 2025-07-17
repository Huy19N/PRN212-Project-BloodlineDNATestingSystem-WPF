using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class StatusDAO
    {
        private readonly GeneCareContext _context;
        public StatusDAO()
        {
            _context = new GeneCareContext();
        }
        public StatusDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<Status?> GetStatusByIdAsync(int statusId)
        {
            try
            {
                return await _context.Statuses.FindAsync(statusId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the status.", ex);
            }
        }

        public async Task<List<Status>> GetAllStatussAsync()
        {
            try
            {
                return await _context.Statuses.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all status.", ex);
            }
        }

        public async Task<Status> CreateStatusAsync(Status status)
        {
            try
            {
                _context.Statuses.Add(status);
                await _context.SaveChangesAsync();
                return status;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the status.", ex);
            }
        }

        public async Task<Status> UpdateStatusAsync(Status status)
        {
            try
            {
                _context.Entry(status).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return status;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the status.", ex);
            }
        }

        public async Task<bool> DeleteStatusAsync(int statusId)
        {
            try
            {
                var status = await _context.Statuses.FindAsync(statusId);
                if (status == null)
                {
                    return false; // Status not found
                }
                _context.Statuses.Remove(status);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the status.", ex);
            }
        }
    }
}
