using BusinessObjects;
using Repositories;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AdminService : IAdminService
    {
        private readonly IBookingRepository bookingRepository = new BookingRepository();

        public async Task<ReturnData> GetAndSearchBooking(string key, int numberRecordsEachPage, int currentPage)
        {
            return await bookingRepository.GetAndSearchBooking(key, numberRecordsEachPage, currentPage);
        }

    }
}
