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
        private readonly IBookingRepository bookingRepository;
        private readonly IServicePriceRepository servicePriceRepository;
        private readonly ISampleRepository sampleRepository;
        private readonly IStatusRepository statusRepository;
        private readonly ICollectionMethodRepository collectionMethodRepository;

        public AdminService()
        {
            bookingRepository = new BookingRepository();
            servicePriceRepository = new ServicePriceRepository();
            sampleRepository = new SampleRepository();
            statusRepository = new StatusRepository();
            collectionMethodRepository = new CollectionMethodRepository();
        }
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

        public List<CollectionMethod>? GetAllCollectionMethods()
        {
            return collectionMethodRepository.GetCollectionAll();
        }

        public ServicePrice? GetServicePriceByServiceAndDuration(int serviceId, int durationId)
        {
            return servicePriceRepository.GetServicePriceByServiceAndDuration(serviceId, durationId);
        }
        public bool deleteBookingById(int bookingId)
        {
            return bookingRepository.deleteBookingById(bookingId);
        }
        public bool UpdateBookingWithPatients(Booking booking)
        {
            return bookingRepository.UpdateBookingWithPatients(booking);
        }
    }
}
