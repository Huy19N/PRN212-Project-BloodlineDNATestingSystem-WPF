using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class BookingDAO
    {
        GeneCarePrnContext context = new GeneCarePrnContext();

        public List<Booking> GetAllBookings()
        {
            return context.Bookings.ToList();
        }

        public Booking GetBookingById(int id)
        {
            return context.Bookings.FirstOrDefault(b => b.BookingId == id);
        }

        public bool AddBooking(Booking booking)
        {
            context.Bookings.Add(booking);
            return context.SaveChanges() > 0;
        }

        public bool DeleteBooking(Booking booking)
        {
            context.Bookings.Remove(booking);
            return context.SaveChanges() > 0;
        }

        public bool UpdateBooking(Booking booking)
        {
            context.Bookings.Update(booking);
            return context.SaveChanges() > 0;
        }

        public List<Booking> GetBookingsByUserID(int userId)
        {
            return context.Bookings
                .Where(b => b.UserId == userId)
                .ToList();
        }

        public List<Booking> GetBookingsByDurationId(int durationId)
        {
            return context.Bookings
                .Where(b => b.DurationId == durationId)
                .ToList();
        }

        public List<Booking> GetBookingsByServiceId(int serviceId)
        {
            return context.Bookings
                .Where(b => b.ServiceId == serviceId)
                .ToList();
        }

        public List<Booking> GetBookingsByMethodId(int methodId)
        {
            return context.Bookings
                .Where(b => b.MethodId == methodId)
                .ToList();
        }

        public List<Booking> GetBookingsByResultId(int resultId)
        {
            return context.Bookings
                .Where(b => b.ResultId == resultId)
                .ToList();
        }

        public List<Booking> GetBookingsByStatusId(int statusId)
        {
            return context.Bookings
                .Where(b => b.StatusId == statusId)
                .ToList();
        }
    }
}
