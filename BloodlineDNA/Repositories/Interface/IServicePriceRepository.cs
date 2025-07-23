using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories.Interface
{
    public interface IServicePriceRepository
    {
        public List<ServicePrice> GetAllServicePrices();
        public ServicePrice GetServicePriceById(int id);
        public bool AddServicePrice(ServicePrice servicePrice);
        public bool DeleteServicePrice(ServicePrice servicePrice);
        public bool UpdateServicePrice(ServicePrice servicePrice);
        public List<ServicePrice> GetServicePricesByServiceId(int serviceId);
        public List<ServicePrice> GetServicePricesByDurationId(int durationId);

    }
}
