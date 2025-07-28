using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class BookingDAO
    {
        GeneCarePrnContext context = new GeneCarePrnContext();

        public List<Booking> GetAllBookings()
        {
            return context.Bookings.ToList();
        }

        public Booking? GetBookingById(int id)
        {
            try
            {
                var booking = context.Bookings
                    .Include(b => b.ServicePrice)
                        .ThenInclude(sp => sp.Service)
                    .Include(b => b.ServicePrice)
                        .ThenInclude(sp => sp.Duration)
                    .Include(b => b.Method)
                    .Include(b => b.Patients)
                    .Include(b => b.Status)
                    .Include(b => b.TestResult)
                    .FirstOrDefault(b => b.BookingId == id);
                context.Entry(booking).State = EntityState.Detached;
                return booking;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
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

        public async Task<ReturnData> GetAndSearchBooking(string? key, int numberRecordsEachPage, int currentPage)
        {
            try
            {

                var query = context.Bookings
                            .Include(b => b.User)
                            .Include(b => b.ServicePrice)
                                .ThenInclude(sp => sp.Service)
                            .Include(b => b.ServicePrice)
                                .ThenInclude(sp => sp.Duration)
                            .Include(b => b.Method)
                            .Include(b => b.TestResult)
                            .Include(b => b.Status)
                            .Where(b => b.BookingId.ToString().Contains(key ?? "") ||
                                        b.Method.MethodName.Contains(key ?? "") ||
                                        b.TestResult.ResultSummary.Contains(key ?? "") ||
                                        b.Status.StatusName.Contains(key ?? "") ||
                                        b.ServicePrice.Duration.DurationName.Contains(key ?? "") ||
                                        b.ServicePrice.Service.ServiceType.Contains(key ?? ""));

                int totalRecords = await query.CountAsync();

                int maxPage = (int)Math.Ceiling((double)totalRecords / numberRecordsEachPage);

                var pagedData = await query.Skip((currentPage - 1) * numberRecordsEachPage)
                                           .Take(numberRecordsEachPage)
                                           .ToListAsync();

                return new ReturnData()
                {
                    currentPage = currentPage,
                    numberRecords = totalRecords,
                    maxPage = maxPage,
                    Data = pagedData
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);

            }
        }
        public List<Booking> GetBookingsByUserID(int userId)
        {
            return context.Bookings
                .Where(b => b.UserId == userId)
                .ToList();
        }


        public List<Booking> GetBookingsByMethodId(int methodId)
        {
            return context.Bookings
                .Where(b => b.MethodId == methodId)
                .ToList();
        }


        public List<Booking> GetBookingsByStatusId(int statusId)
        {
            return context.Bookings
                .Where(b => b.StatusId == statusId)
                .ToList();
        }
        public bool deleteBookingById(int bookingId)
        {
            var booking = context.Bookings.Find(bookingId);
            if (booking == null)
            {
                return false;
            }
            context.TestResults.Remove(context.TestResults.Find(bookingId));
            context.Patients.RemoveRange(context.Patients.Where(p => p.BookingId == bookingId));
            context.Bookings.Remove(booking);
            return context.SaveChanges() > 0;
        }

        public bool UpdateBookingWithPatients(Booking booking)
        {
            try
            {
                var existingBooking = context.Bookings
                    .Include(b => b.Patients)
                    .Include(b => b.TestResult)
                    .FirstOrDefault(b => b.BookingId == booking.BookingId);
                if (existingBooking == null)
                    return false;

                existingBooking.ServicePriceId = booking.ServicePriceId;
                existingBooking.MethodId = booking.MethodId;
                existingBooking.StatusId = booking.StatusId;
                existingBooking.Date = booking.Date;

                existingBooking.Patients.Clear();
                foreach (var patient in booking.Patients)
                {
                    var trackedPatient = context.Patients.Local
                        .FirstOrDefault(p => p.PatientId == patient.PatientId)
                        ?? context.Patients.Find(patient.PatientId);

                    if (trackedPatient != null)
                        existingBooking.Patients.Add(trackedPatient);
                    else
                        existingBooking.Patients.Add(patient);
                }

                if (booking.TestResult != null)
                {
                    var existingTestResult = context.TestResults
                        .FirstOrDefault(tr => tr.BookingId == booking.BookingId);

                    if (existingTestResult != null)
                    {

                        existingTestResult.ResultSummary = booking.TestResult.ResultSummary;
                        existingTestResult.Date = booking.TestResult.Date;
                    }
                    else
                    {
                        booking.TestResult.BookingId = booking.BookingId;
                        context.TestResults.Add(booking.TestResult);
                    }
                }

                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
