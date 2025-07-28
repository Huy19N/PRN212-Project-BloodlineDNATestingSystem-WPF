using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;
using Repositories.Interface;

namespace Repositories
{
    public class BookingRepository : IBookingRepository
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

        public Booking? GetBookingById(int id)
        {
            return BookingDAO.GetBookingById(id);
        }

        public async Task<ReturnData> GetAndSearchBooking(string key, int numberRecordsEachPage, int currentPage)
        {
            return await BookingDAO.GetAndSearchBooking(key, numberRecordsEachPage, currentPage);
        }


        public List<Booking> GetBookingsByMethodId(int methodId)
        {
            return BookingDAO.GetBookingsByMethodId(methodId);
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
