using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class TestResultDAO
    {
        GeneCarePrnContext context = new GeneCarePrnContext();
        public List<TestResult> GetAllTestResults()
        {
            return context.TestResults.ToList();
        }
        
        public bool AddTestResult(TestResult testResult)
        {
            context.TestResults.Add(testResult);
            return context.SaveChanges() > 0;
        }
    
        public bool DeleteTestResult(TestResult testResult)
        {
            context.TestResults.Remove(testResult);
            return context.SaveChanges() > 0;
        }

        public bool UpdateTestResult(TestResult testResult)
        {
            if (context.Bookings.Find(testResult.BookingId) == null)
                return false;
            if (context.TestResults.Find(testResult.BookingId) == null)
            {
                testResult.ResultSummary = testResult.ResultSummary ?? string.Empty;
                
            }else
            {
                var existingTestResult = context.TestResults.Find(testResult.BookingId);
                if (existingTestResult == null)
                    return false;
                existingTestResult.ResultSummary = testResult.ResultSummary ?? string.Empty;
            }
            return context.SaveChanges() > 0;
        }
    }
}

