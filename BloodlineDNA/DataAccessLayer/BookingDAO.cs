using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookingDAO
    {
        private readonly GeneCareContext _context;
        public BookingDAO()
        {
            _context = new GeneCareContext();
        }
        public BookingDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<Booking?> GetBookingByIdAsync(int bookingId)
        {
            try
            {
                return await _context.Bookings.FindAsync(bookingId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the booking.", ex);
            }
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            try
            {
                return await _context.Bookings.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all booking.", ex);
            }
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            try
            {
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();
                return booking;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the booking.", ex);
            }
        }

        public async Task<Booking> UpdateBookingAsync(Booking booking)
        {
            try
            {
                _context.Entry(booking).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return booking;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the booking.", ex);
            }
        }

        public async Task<bool> DeleteBookingAsync(int bookingId)
        {
            try
            {
                var booking = await _context.Bookings.FindAsync(bookingId);
                if (booking == null)
                {
                    return false; // Booking not found
                }
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the booking.", ex);
            }
        }
    }
}
