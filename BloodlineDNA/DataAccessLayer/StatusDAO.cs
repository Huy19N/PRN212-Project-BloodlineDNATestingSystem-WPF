using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class StatusDAO
    {
        GeneCarePrnContext context = new GeneCarePrnContext();
        public List<Status>? GetAllStatuses()
        {
            return context.Statuses.ToList();
        }
        public Status GetStatusById(int id)
        {
            return context.Statuses.FirstOrDefault(s => s.StatusId == id);
        }
        public bool AddStatus(Status status)
        {
            context.Statuses.Add(status);
            return context.SaveChanges() > 0;
        }
        public bool DeleteStatus(Status status)
        {
            context.Statuses.Remove(status);
            return context.SaveChanges() > 0;
        }
        public bool UpdateStatus(Status status)
        {
            context.Statuses.Update(status);
            return context.SaveChanges() > 0;
        }
    }
}
