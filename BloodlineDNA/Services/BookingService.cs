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
    public class BookingService : Interface.IBookingService
    {
        IBookingRepository bookingRepository;

        public BookingService()
        {
            bookingRepository = new BookingRepository();
        }
        public bool AddBooking(Booking booking)
        {
            return bookingRepository.AddBooking(booking);
        }

        public bool DeleteBooking(Booking booking)
        {
            return bookingRepository.DeleteBooking(booking);
        }

        public List<Booking> GetAllBookings()
        {
            return bookingRepository.GetAllBookings();
        }

        public Booking GetBookingById(int id)
        {
            return bookingRepository.GetBookingById(id);
        }

        public List<Booking> GetBookingsByDurationId(int durationId)
        {
            return bookingRepository.GetBookingsByStatusId(durationId);
        }

        public List<Booking> GetBookingsByMethodId(int methodId)
        {
            return bookingRepository.GetBookingsByResultId(methodId);
        }

        public List<Booking> GetBookingsByResultId(int resultId)
        {
            return bookingRepository.GetBookingsByResultId(resultId);
        }

        public List<Booking> GetBookingsByServiceId(int serviceId)
        {
            return bookingRepository.GetBookingsByServiceId(serviceId);
        }

        public List<Booking> GetBookingsByStatusId(int statusId)
        {
            return bookingRepository.GetBookingsByStatusId(statusId);
        }

        public List<Booking> GetBookingsByUserID(int userId)
        {
            return bookingRepository.GetBookingsByUserID(userId);
        }

        public bool UpdateBooking(Booking booking)
        {
            return bookingRepository.UpdateBooking(booking);
        }
    }
}
