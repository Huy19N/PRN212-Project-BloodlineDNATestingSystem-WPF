using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class CollectionMethodRepository : Interface.ICollectionMethodRepository
    {
        CollectionMethodDAO CollectionMethodDAO = new CollectionMethodDAO();
        public bool AddCollectionMethod(CollectionMethod collectionMethod)
        {
            return CollectionMethodDAO.AddCollectionMethod(collectionMethod);
        }

        public bool DeleteCollectionMethod(CollectionMethod collectionMethod)
        {
            return CollectionMethodDAO.DeleteCollectionMethod(collectionMethod);
        }

        public List<CollectionMethod> GetCollectionAll()
        {
            return CollectionMethodDAO.GetCollectionAll();
        }

        public CollectionMethod GetCollectionMethodById(int id)
        {
            return CollectionMethodDAO.GetCollectionMethodById(id);
        }

        public bool UpdateCollectionMethod(CollectionMethod collectionMethod)
        {
            return CollectionMethodDAO.UpdateCollectionMethod(collectionMethod);
        }
    }
}
