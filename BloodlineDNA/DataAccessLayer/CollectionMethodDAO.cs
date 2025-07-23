using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class CollectionMethodDAO
    {
        GeneCarePrnContext context = new GeneCarePrnContext();

        public List<CollectionMethod> GetCollectionAll()
        {
            return context.CollectionMethods.ToList();
        }

        public CollectionMethod GetCollectionMethodById(int id)
        {
            return context.CollectionMethods.FirstOrDefault(c => c.MethodId == id);
        }

        public bool AddCollectionMethod(CollectionMethod collectionMethod)
        {
            context.CollectionMethods.Add(collectionMethod);
            return context.SaveChanges() > 0;
        }

        public bool DeleteCollectionMethod(CollectionMethod collectionMethod)
        {
            context.CollectionMethods.Remove(collectionMethod);
            return context.SaveChanges() > 0;
        }

        public bool UpdateCollectionMethod(CollectionMethod collectionMethod)
        {
            context.CollectionMethods.Update(collectionMethod);
            return context.SaveChanges() > 0;
        }

        
    }
}
