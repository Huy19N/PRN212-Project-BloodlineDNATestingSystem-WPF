using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TestResultDAO
    {
        private readonly GeneCareContext _context;
        public TestResultDAO()
        {
            _context = new GeneCareContext();
        }
        public TestResultDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<TestResult?> GetTestResultByIdAsync(int resultId)
        {
            try
            {
                return await _context.TestResults.FindAsync(resultId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the test result.", ex);
            }
        }

        public async Task<List<TestResult>> GetAllTestResultsAsync()
        {
            try
            {
                return await _context.TestResults.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all test result.", ex);
            }
        }

        public async Task<TestResult> CreateTestResultAsync(TestResult testResult)
        {
            try
            {
                _context.TestResults.Add(testResult);
                await _context.SaveChangesAsync();
                return testResult;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the test result.", ex);
            }
        }

        public async Task<TestResult> UpdateTestResultAsync(TestResult testResult)
        {
            try
            {
                _context.Entry(testResult).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return testResult;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the test result.", ex);
            }
        }

        public async Task<bool> DeleteTestResultAsync(int resultId)
        {
            try
            {
                var testResult = await _context.TestResults.FindAsync(resultId);
                if (testResult == null)
                {
                    return false; // Test result not found
                }
                _context.TestResults.Remove(testResult);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the test result.", ex);
            }
        }
    }
}
