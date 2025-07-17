using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DurationDAO
    {
        private readonly GeneCareContext _context;
        public DurationDAO()
        {
            _context = new GeneCareContext();
        }
        public DurationDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<Duration?> GetDurationByIdAsync(int durationId)
        {
            try
            {
                return await _context.Durations.FindAsync(durationId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the duration.", ex);
            }
        }

        public async Task<List<Duration>> GetAllDurationsAsync()
        {
            try
            {
                return await _context.Durations.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all duration.", ex);
            }
        }

        public async Task<Duration> CreateDurationAsync(Duration duration)
        {
            try
            {
                _context.Durations.Add(duration);
                await _context.SaveChangesAsync();
                return duration;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the duration.", ex);
            }
        }

        public async Task<Duration> UpdateDurationAsync(Duration duration)
        {
            try
            {
                _context.Entry(duration).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return duration;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the duration.", ex);
            }
        }

        public async Task<bool> DeleteDurationAsync(int durationId)
        {
            try
            {
                var duration = await _context.Durations.FindAsync(durationId);
                if (duration == null)
                {
                    return false; // Duration not found
                }
                _context.Durations.Remove(duration);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the duration.", ex);
            }
        }
    }
}
