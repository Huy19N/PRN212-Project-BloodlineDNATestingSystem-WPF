using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public class TestResultDAO
{
    public List<TestResult> GetAllTestResults()
    {
        using var context = new GeneCareContext();
        return context.TestResults.ToList();
    }
    public bool CreateTestResults(TestResult testResult)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (testResult == null)
            {
                return false;
            }

            context.TestResults.Add(new TestResult
            {
                BookingId = testResult.BookingId,
                Date = testResult.Date,
                ResultSummary = testResult.ResultSummary,
            });
            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
    public bool UpdateTestResults(TestResult testResult)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (testResult == null)
            {
                return false;
            }
            var existingTestResult = context.TestResults.Find(testResult.ResultId);
            if (existingTestResult == null)
            {
                return false;
            }
            existingTestResult.BookingId = testResult.BookingId;
            existingTestResult.Date = testResult.Date;
            existingTestResult.ResultSummary = testResult.ResultSummary;

            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
    public bool DeleteTestResultsById(int id)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            var testResult = context.TestResults.Find(id);
            if (testResult == null)
            {
                return false;
            }
            context.TestResults.Remove(testResult);
            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
}
