using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class ServiceRepository : Interface.IServiceRepository
    {
        ServiceDAO serviceDAO = new ServiceDAO();
        public bool AddService(Service service)
        {
            return serviceDAO.AddService(service);
        }

        public bool DeleteService(Service service)
        {
            return serviceDAO.DeleteService(service);
        }

        public List<Service> GetAllServices()
        {
            return serviceDAO.GetAllServices();
        }

        public Service GetServiceById(int id)
        {
            return serviceDAO.GetServiceById(id);
        }

        public bool UpdateService(Service service)
        {
            return serviceDAO.UpdateService(service);
        }
    }
}
