using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories.Interface
{
    public interface IServiceRepository
    {
        public List<Service> GetAllServices();
        public Service GetServiceById(int id);
        public bool AddService(Service service);
        public bool DeleteService(Service service);
        public bool UpdateService(Service service);
    }
}
