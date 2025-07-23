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
    public class StatusService : Interface.IStatusService
    {
        IStatusRepository statusRepository;

        public StatusService()
        {
            statusRepository = new StatusRepository();
        }
        public bool AddStatus(Status status)
        {
            return statusRepository.AddStatus(status);
        }

        public bool DeleteStatus(Status status)
        {
            return statusRepository.DeleteStatus(status);
        }

        public List<Status> GetAllStatuses()
        {
            return statusRepository.GetAllStatuses();
        }

        public Status GetStatusById(int id)
        {
            return statusRepository.GetStatusById(id);
        }

        public bool UpdateStatus(Status status)
        {
            return statusRepository.UpdateStatus(status);
        }
    }
}
