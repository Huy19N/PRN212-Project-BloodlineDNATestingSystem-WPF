using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Services.Interface
{
    public interface IDurationService
    {
        public List<Duration> GetAllDurations();
        public Duration GetDurationById(int id);
        public bool AddDuration(Duration duration);
        public bool DeleteDuration(Duration duration);
        public bool UpdateDuration(Duration duration);
    }
}
