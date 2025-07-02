using BusinessObjects;

namespace DataAccessLayer;

public class DurationDAO
{
    public List<Duration> GetAllDurations()
    {
        using var context = new GeneCareContext();
        return context.Durations.ToList();
    }
    public bool CreateDuration(Duration duration)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (duration == null || String.IsNullOrWhiteSpace(duration.DurationName))
            {
                return false;
            }
            context.Durations.Add(new Duration
            {
                DurationName = duration.DurationName,
                Time = duration.Time,
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
    public bool UpdateDuration(Duration duration)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (duration == null ||
                String.IsNullOrWhiteSpace(duration.DurationName))
            {
                return false;
            }
            var existingDuration = context.Durations.Find(duration.DurationId);
            if (existingDuration == null)
            {
                return false;
            }

            existingDuration.DurationName = duration.DurationName;
            existingDuration.Time = duration.Time;

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
    public bool DeleteDurationById(int id)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            var duration = context.Durations.Find(id);
            if (duration == null) return false;
            context.Durations.Remove(duration);

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
