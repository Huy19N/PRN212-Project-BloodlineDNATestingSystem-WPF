using BusinessObjects;

namespace DataAccessLayer;

public class ServiceDAO
{
    public List<Service> GetAllServices()
    {
        using var context = new GeneCareContext();
        return context.Services.ToList();
    }
    public bool CreateService(Service service)
    {
        using var context = new GeneCareContext();
        if (service == null)
        {
            return false;
        }
        using var transaction = context.Database.BeginTransaction();
        try
        {
            context.Services.Add(new Service
            {
                ServiceName = service.ServiceName,
                ServiceType = service.ServiceType,
                Description = service.Description
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
    public bool UpdateService(Service service)
    {
        using var context = new GeneCareContext();
        if (service == null)
        {
            return false;
        }
        var existingService = context.Services.Find(service.ServiceId);
        if (existingService == null)
        {
            return false;
        }
        using var transaction = context.Database.BeginTransaction();
        try
        {
            existingService.ServiceName = service.ServiceName;
            existingService.ServiceType = service.ServiceType;
            existingService.Description = service.Description;

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
    public bool DeleteServiceById(int id)
    {
        using var context = new GeneCareContext();
        var service = context.Services.Find(id);
        if (service == null) return false;

        using var transaction = context.Database.BeginTransaction();
        try
        {
            context.Services.Remove(service);
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
