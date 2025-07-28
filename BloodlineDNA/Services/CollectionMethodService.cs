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
        ICollectionMethodRepository repository;

        public CollectionMethodService()
        {
            repository = new CollectionMethodRepository();
        }
        public bool AddCollectionMethod(CollectionMethod collectionMethod)
        {
            return repository.AddCollectionMethod(collectionMethod);
        }

        public bool DeleteCollectionMethod(CollectionMethod collectionMethod)
        {
            return  repository.DeleteCollectionMethod(collectionMethod);
        }

        public List<CollectionMethod> GetCollectionAll()
        {
            return repository.GetCollectionAll();
        }

        public CollectionMethod GetCollectionMethodById(int id)
        {
            return repository.GetCollectionMethodById(id);
        }

        public bool UpdateCollectionMethod(CollectionMethod collectionMethod)
        {
            return repository.UpdateCollectionMethod(collectionMethod);
        }
    }
}
