using BusinessObjects;

namespace DataAccessLayer;

public class TestStepDAO
{

    public List<TestStep> GetAllTestStep()
    {
        using var context = new GeneCareContext();
        return context.TestSteps.ToList();
    }
    public bool CreateTestStep(TestStep testStep)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (testStep == null) return false;
            if (context.TestSteps.Find(testStep.StepId) != null) return false;

            context.TestSteps.Add(new TestStep
            {
                StepName = testStep.StepName
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
    public bool UpdateTestStep(TestStep testStep)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (testStep == null || String.IsNullOrWhiteSpace(testStep.StepName)) return false;
            var existTestStep = context.TestSteps.Find(testStep.StepId);
            if (existTestStep == null) return false;

            existTestStep.StepName = testStep.StepName;
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
    public bool DeleteTestStepById(int id)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            var testStep = context.TestSteps.Find(id);
            if (testStep == null) return false;

            context.TestSteps.Remove(testStep);
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
