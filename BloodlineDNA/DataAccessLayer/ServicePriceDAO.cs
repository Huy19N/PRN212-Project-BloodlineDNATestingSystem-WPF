using BusinessObjects;

namespace DataAccessLayer;

public class ServicePriceDAO
{
    public List<ServicePrice> GetAllServicePrices()
    {
        using var context = new GeneCareContext();
        return context.ServicePrices.ToList();
    }
    public bool CreateServicePrice(ServicePrice servicePrice)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (servicePrice == null) return false;

            context.ServicePrices.Add(new ServicePrice
            {
                ServiceId = servicePrice.ServiceId,
                DurationId = servicePrice.DurationId,
                Price = servicePrice.Price
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
    public bool UpdateServicePrice(ServicePrice servicePrice)
    {
        using var context = new GeneCareContext();
        var existingServicePrice = context.ServicePrices.Find(servicePrice.PriceId);
        if (servicePrice == null)
        {
            return false;
        }
        if (existingServicePrice == null)
        {
            return false;
        }
        using var transaction = context.Database.BeginTransaction();
        try
        {
            existingServicePrice.ServiceId = servicePrice.ServiceId;
            existingServicePrice.DurationId = servicePrice.DurationId;
            existingServicePrice.Price = servicePrice.Price;

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
    public bool DeleteServicePriceById(int id)
    {
        using var context = new GeneCareContext();
        var servicePrice = context.ServicePrices.Find(id);
        if (servicePrice == null) return false;

        using var transaction = context.Database.BeginTransaction();
        try
        {
            context.ServicePrices.Remove(servicePrice);

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
