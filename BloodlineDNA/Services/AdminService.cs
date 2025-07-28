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
        private readonly IServicePriceRepository servicePriceRepository = new ServicePriceRepository();
        private readonly ISampleRepository sampleRepository = new SampleRepository();
        private readonly IStatusRepository statusRepository = new StatusRepository();

        public async Task<ReturnData> GetAndSearchBooking(string key, int numberRecordsEachPage, int currentPage)
        {
            return await bookingRepository.GetAndSearchBooking(key, numberRecordsEachPage, currentPage);
        }

        public Booking? GetBookingById(int id)
        {
            return bookingRepository.GetBookingById(id);
        }

        public List<ServicePrice>? GetAllAvailableServicePrices()
        {
            return servicePriceRepository.GetAllAvailableServicePrices();
        }

        public List<Sample>? GetAllSamples()
        {
            return sampleRepository.GetAllSamples();
        }

        public List<Status>? GetAllStatuses()
        {
            return statusRepository.GetAllStatuses();
        }
    }
}
