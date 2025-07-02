using BusinessObjects;

namespace DataAccessLayer;

public class CollectionMethodDAO
{
    public List<CollectionMethod> GetAllCollectionMethods()
    {
        using var context = new GeneCareContext();
        return context.CollectionMethods.ToList();
    }
    public bool CreateCollectionMethod(CollectionMethod collectionMethod)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (collectionMethod == null ||
                String.IsNullOrWhiteSpace(collectionMethod.MethodName))
                return false;

            context.CollectionMethods.Add(new CollectionMethod
            {
                MethodName = collectionMethod.MethodName
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
    public bool UpdateCollectionMethod(CollectionMethod collectionMethod)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (collectionMethod == null ||
                String.IsNullOrWhiteSpace(collectionMethod.MethodName))
                return false;

            var existCollectionMethod = context.CollectionMethods.Find(collectionMethod.MethodId);
            if (existCollectionMethod == null)
                return false;

            existCollectionMethod.MethodId = collectionMethod.MethodId;
            existCollectionMethod.MethodName = collectionMethod.MethodName;

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
    public bool DeleteCollectionMethodById(int id)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            var collectionMethod = context.CollectionMethods.Find(id);
            if (collectionMethod == null) return false;

            context.CollectionMethods.Remove(collectionMethod);
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
