using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IAdminService
    {
        Task<ReturnData> GetAndSearchBooking(string key, int numberRecordsEachPage, int currentPage);

    }
}
