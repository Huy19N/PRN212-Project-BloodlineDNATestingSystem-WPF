using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TestProcessDAO
    {
        private readonly GeneCareContext _context;
        public TestProcessDAO()
        {
            _context = new GeneCareContext();
        }
        public TestProcessDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<TestProcess?> GetTestProcessByIdAsync(int processId)
        {
            try
            {
                return await _context.TestProcesses.FindAsync(processId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the test process.", ex);
            }
        }

        public async Task<List<TestProcess>> GetAllTestProcesssAsync()
        {
            try
            {
                return await _context.TestProcesses.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all test process.", ex);
            }
        }

        public async Task<TestProcess> CreateTestProcessAsync(TestProcess testResult)
        {
            try
            {
                _context.TestProcesses.Add(testResult);
                await _context.SaveChangesAsync();
                return testResult;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the test process.", ex);
            }
        }

        public async Task<TestProcess> UpdateTestProcessAsync(TestProcess testResult)
        {
            try
            {
                _context.Entry(testResult).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return testResult;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the test process.", ex);
            }
        }

        public async Task<bool> DeleteTestProcessAsync(int processId)
        {
            try
            {
                var testResult = await _context.TestProcesses.FindAsync(processId);
                if (testResult == null)
                {
                    return false; // Test process  not found
                }
                _context.TestProcesses.Remove(testResult);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the test process.", ex);
            }
        }
    }
}
