using BusinessObjects;

namespace DataAccessLayer;

public class StatusDAO
{
    public List<Status> GetAllStatus()
    {
        using var context = new GeneCareContext();
        return context.Statuses.ToList();
    }
    public bool CreateStatus(Status status)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (status == null || context.Statuses.Find(status.StatusId) != null) return false;
            context.Statuses.Add(new Status
            {
                StatusName = status.StatusName,
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
    public bool UpdateStatus(Status status)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            var existStatus = context.Statuses.Find(status.StatusId);
            if (existStatus == null) return false;
            existStatus.StatusName = status.StatusName;

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
    public bool DeleteStatusById(int id)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            var status = context.Statuses.Find(id);
            if (status == null) return false;
            context.Statuses.Remove(status);

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
