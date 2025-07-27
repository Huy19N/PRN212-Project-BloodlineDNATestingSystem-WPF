using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Services.Interface
{
    public interface IBookingService
    {
        public List<Booking> GetAllBookings();
        public Booking GetBookingById(int id);
        public bool AddBooking(Booking booking);
        public bool DeleteBooking(Booking booking);
        public bool UpdateBooking(Booking booking);
        Task<ReturnData> GetAndSearchBooking(string key, int numberRecordsEachPage, int currentPage);
        public List<Booking> GetBookingsByUserID(int userId);
        public List<Booking> GetBookingsByDurationId(int durationId);
        public List<Booking> GetBookingsByStatusId(int statusId);
    }
}
