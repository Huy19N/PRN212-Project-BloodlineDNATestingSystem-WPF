using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class ServiceDAO
    {
        GeneCarePrnContext context = new GeneCarePrnContext();
        public List<Service> GetAllServices()
        {
            return context.Services.ToList();
        }
        public Service GetServiceById(int id)
        {
            return context.Services.FirstOrDefault(s => s.ServiceId == id);
        }
        public bool AddService(Service service)
        {
            context.Services.Add(service);
            return context.SaveChanges() > 0;
        }
        public bool DeleteService(Service service)
        {
            context.Services.Remove(service);
            return context.SaveChanges() > 0;
        }
        public bool UpdateService(Service service)
        {
            context.Services.Update(service);
            return context.SaveChanges() > 0;
        }
    }
}
