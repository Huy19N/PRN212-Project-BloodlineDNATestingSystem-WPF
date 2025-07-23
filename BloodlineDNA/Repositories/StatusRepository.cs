using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class StatusRepository : Interface.IStatusRepository
    {
        StatusDAO statusDAO = new StatusDAO();
        public bool AddStatus(Status status)
        {
            return statusDAO.AddStatus(status);
        }

        public bool DeleteStatus(Status status)
        {
            return statusDAO.DeleteStatus(status);
        }

        public List<Status> GetAllStatuses()
        {
            return statusDAO.GetAllStatuses();
        }

        public Status GetStatusById(int id)
        {
            return statusDAO.GetStatusById(id);
        }

        public bool UpdateStatus(Status status)
        {
            return statusDAO.UpdateStatus(status);
        }
    }
}
