using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories.Interface
{
    public interface ICollectionMethodRepository
    {
        public List<CollectionMethod>? GetCollectionAll();
        public CollectionMethod GetCollectionMethodById(int id);
        public bool AddCollectionMethod(CollectionMethod collectionMethod);
        public bool DeleteCollectionMethod(CollectionMethod collectionMethod);
        public bool UpdateCollectionMethod(CollectionMethod collectionMethod);

    }
}
