using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class ServicePriceRepository : Interface.IServicePriceRepository
    {
        ServicePriceDAO servicePriceDAO = new ServicePriceDAO();
        public bool AddServicePrice(ServicePrice servicePrice)
        {
            return servicePriceDAO.AddServicePrice(servicePrice);
        }

        public bool DeleteServicePrice(ServicePrice servicePrice)
        {
            return servicePriceDAO.DeleteServicePrice(servicePrice);
        }

        public List<ServicePrice> GetAllServicePrices()
        {
            return servicePriceDAO.GetAllServicePrices();
        }

        public ServicePrice GetServicePriceById(int id)
        {
            return servicePriceDAO.GetServicePriceById(id);
        }

        public List<ServicePrice> GetServicePricesByDurationId(int durationId)
        {
            return servicePriceDAO.GetServicePricesByServiceId(durationId);
        }

        public List<ServicePrice> GetServicePricesByServiceId(int serviceId)
        {
            return servicePriceDAO.GetServicePricesByServiceId(serviceId);
        }

        public bool UpdateServicePrice(ServicePrice servicePrice)
        {
            return servicePriceDAO.UpdateServicePrice(servicePrice);
        }
    }
}
