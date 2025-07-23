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
    public class ServiceService : Interface.IServiceService
    {
        IServiceRepository serviceRepository;

        public ServiceService()
        {
            serviceRepository = new ServiceRepository();
        }
        public bool AddService(Service service)
        {
            return serviceRepository.AddService(service);
        }

        public bool DeleteService(Service service)
        {
            return serviceRepository.DeleteService(service);
        }

        public List<Service> GetAllServices()
        {
            return serviceRepository.GetAllServices();
        }

        public Service GetServiceById(int id)
        {
            return serviceRepository.GetServiceById(id);
        }

        public bool UpdateService(Service service)
        {
            return serviceRepository.UpdateService(service);
        }
    }
}
