using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories.Interface
{
    public interface IStatusRepository
    {
        public List<Status> GetAllStatuses();
        public Status GetStatusById(int id);
        public bool AddStatus(Status status);
        public bool DeleteStatus(Status status);
        public bool UpdateStatus(Status status);

    }
}
