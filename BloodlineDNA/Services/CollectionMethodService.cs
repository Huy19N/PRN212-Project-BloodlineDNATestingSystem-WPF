using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;
using Repositories.Interface;

namespace Services
{
    public class CollectionMethodService : Interface.ICollectionMethodService
    {
        ICollectionMethodRepository collectionMethodRepository;

        public CollectionMethodService()
        {
            collectionMethodRepository = new CollectionMethodRepository();
        }
        public bool AddCollectionMethod(CollectionMethod collectionMethod)
        {
            return collectionMethodRepository.AddCollectionMethod(collectionMethod);
        }

        public bool DeleteCollectionMethod(CollectionMethod collectionMethod)
        {
            return collectionMethodRepository.DeleteCollectionMethod(collectionMethod);
        }

        public List<CollectionMethod> GetCollectionAll()
        {
            return collectionMethodRepository.GetCollectionAll();
        }

        public CollectionMethod GetCollectionMethodById(int id)
        {
            return collectionMethodRepository.GetCollectionMethodById(id);
        }

        public bool UpdateCollectionMethod(CollectionMethod collectionMethod)
        {
            return collectionMethodRepository.UpdateCollectionMethod(collectionMethod);
        }
    }
}
