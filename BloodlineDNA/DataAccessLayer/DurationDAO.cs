using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class DurationDAO
    {
        GeneCarePrnContext context = new GeneCarePrnContext();
        public List<Duration> GetAllDurations()
        {
            return context.Durations.ToList();
        }
        public Duration GetDurationById(int id)
        {
            return context.Durations.FirstOrDefault(d => d.DurationId == id);
        }
        public bool AddDuration(Duration duration)
        {
            context.Durations.Add(duration);
            return context.SaveChanges() > 0;
        }
        public bool DeleteDuration(Duration duration)
        {
            context.Durations.Remove(duration);
            return context.SaveChanges() > 0;
        }
        public bool UpdateDuration(Duration duration)
        {
            context.Durations.Update(duration);
            return context.SaveChanges() > 0;
        }
    }
}
