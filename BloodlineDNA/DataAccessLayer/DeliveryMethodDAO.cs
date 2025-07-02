using BusinessObjects;

namespace DataAccessLayer;

public class DeliveryMethodDAO
{
    public List<DeliveryMethod> GetAllDeliveryMethods()
    {
        using var context = new GeneCareContext();
        return context.DeliveryMethods.ToList();
    }
    public bool CreateDeliveryMethod(DeliveryMethod deliveryMethod)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (deliveryMethod == null ||
                String.IsNullOrWhiteSpace(deliveryMethod.DeliveryMethodName))
                return false;

            context.DeliveryMethods.Add(new DeliveryMethod
            {
                DeliveryMethodName = deliveryMethod.DeliveryMethodName
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
    public bool UpdateDeliveryMethod(DeliveryMethod deliveryMethod)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (deliveryMethod == null ||
                String.IsNullOrWhiteSpace(deliveryMethod.DeliveryMethodName))
                return false;

            var existDeliveryMethod = context.DeliveryMethods.Find(deliveryMethod.DeliveryMethodId);
            if (existDeliveryMethod == null)
                return false;

            existDeliveryMethod.DeliveryMethodId = deliveryMethod.DeliveryMethodId;
            existDeliveryMethod.DeliveryMethodName = deliveryMethod.DeliveryMethodName;

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
    public bool DeleteDeliveryMethodById(int id)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            var deliveryMethod = context.DeliveryMethods.Find(id);
            if (deliveryMethod == null) return false;

            context.DeliveryMethods.Remove(deliveryMethod);
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
