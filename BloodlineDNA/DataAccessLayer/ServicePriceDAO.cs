using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class ServicePriceDAO
    {
        GeneCarePrnContext context = new GeneCarePrnContext();
        public List<ServicePrice> GetAllServicePrices()
        {
            return context.ServicePrices.ToList();
        }
        public ServicePrice GetServicePriceById(int id)
        {
            return context.ServicePrices.FirstOrDefault(sp => sp.PriceId == id);
        }
        public bool AddServicePrice(ServicePrice servicePrice)
        {
            context.ServicePrices.Add(servicePrice);
            return context.SaveChanges() > 0;
        }
        public bool DeleteServicePrice(ServicePrice servicePrice)
        {
            context.ServicePrices.Remove(servicePrice);
            return context.SaveChanges() > 0;
        }
        public bool UpdateServicePrice(ServicePrice servicePrice)
        {
            context.ServicePrices.Update(servicePrice);
            return context.SaveChanges() > 0;
        }

        public List<ServicePrice> GetServicePricesByServiceId(int serviceId)
        {
            return context.ServicePrices
                .Where(sp => sp.ServiceId == serviceId)
                .ToList();
        }

        public List<ServicePrice> GetServicePricesByDurationId(int durationId)
        {
            return context.ServicePrices
                .Where(sp => sp.DurationId == durationId)
                .ToList();
        }
    }
}
