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
    public class ServicePriceService : Interface.IServicePriceService
    {
        IServicePriceRepository servicePriceRepository;

        public ServicePriceService()
        {
            servicePriceRepository = new ServicePriceRepository();
        }
        public bool AddServicePrice(ServicePrice servicePrice)
        {
            return servicePriceRepository.AddServicePrice(servicePrice);
        }

        public bool DeleteServicePrice(ServicePrice servicePrice)
        {
            return servicePriceRepository.DeleteServicePrice(servicePrice);
        }

        public List<ServicePrice> GetAllServicePrices()
        {
            return servicePriceRepository.GetAllServicePrices();
        }

        public ServicePrice GetServicePriceById(int id)
        {
            return servicePriceRepository.GetServicePriceById(id);
        }

        public List<ServicePrice> GetServicePricesByDurationId(int durationId)
        {
            return servicePriceRepository.GetServicePricesByDurationId(durationId);
        }

        public List<ServicePrice> GetServicePricesByServiceId(int serviceId)
        {
            return servicePriceRepository.GetServicePricesByServiceId(serviceId);
        }

        public bool UpdateServicePrice(ServicePrice servicePrice)
        {
            return servicePriceRepository.UpdateServicePrice(servicePrice);
        }
    }
}
