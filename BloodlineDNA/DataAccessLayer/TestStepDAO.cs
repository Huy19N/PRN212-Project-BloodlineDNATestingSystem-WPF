using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TestStepDAO
    {
        private readonly GeneCareContext _context;
        public TestStepDAO()
        {
            _context = new GeneCareContext();
        }
        public TestStepDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<TestStep?> GetTestStepByIdAsync(int stepId)
        {
            try
            {
                return await _context.TestSteps.FindAsync(stepId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the test step.", ex);
            }
        }

        public async Task<List<TestStep>> GetAllTestStepsAsync()
        {
            try
            {
                return await _context.TestSteps.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all test step.", ex);
            }
        }

        public async Task<TestStep> CreateTestStepAsync(TestStep testStep)
        {
            try
            {
                _context.TestSteps.Add(testStep);
                await _context.SaveChangesAsync();
                return testStep;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the test step.", ex);
            }
        }

        public async Task<TestStep> UpdateTestStepAsync(TestStep testStep)
        {
            try
            {
                _context.Entry(testStep).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return testStep;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the test step.", ex);
            }
        }

        public async Task<bool> DeleteTestStepAsync(int stepId)
        {
            try
            {
                var testStep = await _context.TestSteps.FindAsync(stepId);
                if (testStep == null)
                {
                    return false; // Test step not found
                }
                _context.TestSteps.Remove(testStep);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the test step.", ex);
            }
        }
    }
}
