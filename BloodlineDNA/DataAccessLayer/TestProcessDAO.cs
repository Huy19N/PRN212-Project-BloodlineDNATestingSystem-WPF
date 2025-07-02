using BusinessObjects;

namespace DataAccessLayer;

public class TestProcessDAO
{
    public List<TestProcess> GetAllTestProcess()
    {
        using var context = new GeneCareContext();
        return context.TestProcesses.ToList();
    }
    public bool CreateTestProcess(TestProcess testProcess)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (testProcess == null) return false;
            if (context.TestProcesses.Find(testProcess.ProcessId) != null) return false;
            context.TestProcesses.Add(new TestProcess
            {
                BookingId = testProcess.BookingId,
                StepId = testProcess.StepId,
                StatusId = testProcess.StatusId,
                Description = testProcess.Description,
                UpdatedAt = testProcess.UpdatedAt,
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
    public bool UpdateTestProcess(TestProcess testProcess)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (testProcess == null) return false;
            var existTestProcess = context.TestProcesses.Find(testProcess.ProcessId);
            if (existTestProcess == null) return false;

            existTestProcess.BookingId = testProcess.BookingId;
            existTestProcess.StepId = testProcess.StepId;
            existTestProcess.StatusId = testProcess.StatusId;
            existTestProcess.Description = testProcess.Description;
            existTestProcess.UpdatedAt = testProcess.UpdatedAt;

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
    public bool DeleteTestProcessById(int id)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            var testProcess = context.TestProcesses.Find(id);
            if (testProcess == null) return false;

            context.TestProcesses.Remove(testProcess);
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
