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
    public class DurationService : Interface.IDurationService
    {
        IDurationRepository durationRepository;

        public DurationService()
        {
            durationRepository = new DurationRepository();
        }
        public bool AddDuration(Duration duration)
        {
            return durationRepository.AddDuration(duration);
        }

        public bool DeleteDuration(Duration duration)
        {
            return durationRepository.DeleteDuration(duration);
        }

        public List<Duration> GetAllDurations()
        {
            return durationRepository.GetAllDurations();
        }

        public Duration GetDurationById(int id)
        {
            return durationRepository.GetDurationById(id);
        }

        public bool UpdateDuration(Duration duration)
        {
            return durationRepository.UpdateDuration(duration);
        }
    }
}
