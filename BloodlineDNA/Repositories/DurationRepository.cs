using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class DurationRepository : Interface.IDurationRepository
    {
        DurationDAO durationDAO = new DurationDAO();
        public bool AddDuration(Duration duration)
        {
            return durationDAO.AddDuration(duration);
        }

        public bool DeleteDuration(Duration duration)
        {
            return durationDAO.DeleteDuration(duration);
        }

        public List<Duration> GetAllDurations()
        {
            return durationDAO.GetAllDurations();
        }

        public Duration GetDurationById(int id)
        {
            return durationDAO.GetDurationById(id);
        }

        public bool UpdateDuration(Duration duration)
        {
            return durationDAO.UpdateDuration(duration);
        }
    }
}
