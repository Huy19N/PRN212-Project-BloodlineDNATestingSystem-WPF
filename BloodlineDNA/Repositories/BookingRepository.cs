using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class BookingRepository : Interface.IBookingRepository
    {
        BookingDAO BookingDAO = new BookingDAO();
        public bool AddBooking(Booking booking)
        {
            return BookingDAO.AddBooking(booking);
        }

        public bool DeleteBooking(Booking booking)
        {
            return BookingDAO.DeleteBooking(booking);
        }

        public List<Booking> GetAllBookings()
        {
            return BookingDAO.GetAllBookings();
        }

        public Booking GetBookingById(int id)
        {
            return BookingDAO.GetBookingById(id);
        }

        public List<Booking> GetBookingsByDurationId(int durationId)
        {
            return BookingDAO.GetBookingsByDurationId(durationId);
        }

        public List<Booking> GetBookingsByMethodId(int methodId)
        {
            return BookingDAO.GetBookingsByMethodId(methodId);
        }

        public List<Booking> GetBookingsByResultId(int resultId)
        {
            return BookingDAO.GetBookingsByResultId(resultId);
        }

        public List<Booking> GetBookingsByServiceId(int serviceId)
        {
            return BookingDAO.GetBookingsByServiceId(serviceId);
        }

        public List<Booking> GetBookingsByStatusId(int statusId)
        {
            return BookingDAO.GetBookingsByStatusId(statusId);
        }

        public List<Booking> GetBookingsByUserID(int userId)
        {
            return BookingDAO.GetBookingsByUserID(userId);
        }

        public bool UpdateBooking(Booking booking)
        {
            return BookingDAO.UpdateBooking(booking);
        }
    }
}
