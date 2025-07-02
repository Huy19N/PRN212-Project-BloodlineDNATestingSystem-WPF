using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public class BookingDAO
{
    public List<Booking> GetAllBookings()
    {
        using var context = new GeneCareContext();
        return context.Bookings.ToList(); 
    }
    public bool CreateBooking(Booking booking)
    {
        using var context = new GeneCareContext();
        if (booking == null)
        {
            return false;
        }
        using var transaction = context.Database.BeginTransaction();
        try
        {
            context.Bookings.Add(new Booking
            {
                UserId = booking.UserId,
                DurationId = booking.DurationId,
                ServiceId = booking.ServiceId,
                MethodId = booking.MethodId,
                AppointmentTime = booking.AppointmentTime,
                StatusId = booking.StatusId,
                Date = booking.Date,
            });
            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
    public bool UpdateBooking(Booking booking)
    {
        using var context = new GeneCareContext();
        if (booking == null)
        {
            return false;
        }
        var existingBooking = context.Bookings.Find(booking.BookingId);
        if (existingBooking == null)
        {
            return false;
        }
        using var transaction = context.Database.BeginTransaction();
        try
        {
            existingBooking.UserId = booking.UserId;
            existingBooking.DurationId = booking.DurationId;
            existingBooking.ServiceId = booking.ServiceId;
            existingBooking.StatusId = booking.StatusId;
            existingBooking.MethodId = booking.MethodId;
            existingBooking.Date = booking.Date;

            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;

        }
    }
    public bool DeleteBookingById(int id)
    {
        using var context = new GeneCareContext();
        var booking = context.Bookings.Find(id);
        if (booking == null) return false;

        using var transaction = context.Database.BeginTransaction();
        try
        {
            context.Bookings.Remove(booking);

            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
}
