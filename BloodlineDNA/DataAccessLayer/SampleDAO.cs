using BusinessObjects;

namespace DataAccessLayer;

public class SampleDAO
{
    public List<Sample> GetAllSamples()
    {
        using var context = new GeneCareContext();
        return context.Samples.ToList();
    }
    public bool CreateSample(Sample sample)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (sample == null)
            {
                return false;
            }
            context.Samples.Add(new Sample
            {
                BookingId = sample.BookingId,
                PatientId = sample.PatientId,
                Date = sample.Date,
                SampleVariant = sample.SampleVariant,
                CollectBy = sample.CollectBy,
                DeliveryMethodId = sample.DeliveryMethodId,
                Status = sample.Status
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
    public bool UpdateSample(Sample sample)
    {
        using var context = new GeneCareContext();
        if (sample == null)
        {
            return false;
        }

        var existingSample = context.Samples.Find(sample.SampleId);
        if (existingSample == null)
        {
            return false;
        }
        using var transaction = context.Database.BeginTransaction();
        try
        {
            existingSample.BookingId = sample.BookingId;
            existingSample.PatientId = sample.PatientId;
            existingSample.Date = sample.Date;
            existingSample.SampleVariant = sample.SampleVariant;
            existingSample.CollectBy = sample.CollectBy;
            existingSample.DeliveryMethodId = sample.DeliveryMethodId;
            existingSample.Status = sample.Status;

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
    public bool DeleteSampleById(int id)
    {
        using var context = new GeneCareContext();
        var Sample = context.Samples.Find(id);
        if (Sample == null) return false;

        using var transaction = context.Database.BeginTransaction();
        try
        {
            context.Samples.Remove(Sample);
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
