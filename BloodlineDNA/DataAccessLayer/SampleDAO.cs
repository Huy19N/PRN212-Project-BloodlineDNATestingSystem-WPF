using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SampleDAO
    {
        private readonly GeneCareContext _context;
        public SampleDAO()
        {
            _context = new GeneCareContext();
        }
        public SampleDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<Sample?> GetSampleByIdAsync(int sampleId)
        {
            try
            {
                return await _context.Samples.FindAsync(sampleId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the sample.", ex);
            }
        }

        public async Task<List<Sample>> GetAllSamplesAsync()
        {
            try
            {
                return await _context.Samples.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all sample.", ex);
            }
        }

        public async Task<Sample> CreateSampleAsync(Sample sample)
        {
            try
            {
                _context.Samples.Add(sample);
                await _context.SaveChangesAsync();
                return sample;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the sample.", ex);
            }
        }

        public async Task<Sample> UpdateSampleAsync(Sample sample)
        {
            try
            {
                _context.Entry(sample).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return sample;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the sample.", ex);
            }
        }

        public async Task<bool> DeleteSampleAsync(int sampleId)
        {
            try
            {
                var sample = await _context.Samples.FindAsync(sampleId);
                if (sample == null)
                {
                    return false; // Sample not found
                }
                _context.Samples.Remove(sample);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the sample.", ex);
            }
        }
    }
}
