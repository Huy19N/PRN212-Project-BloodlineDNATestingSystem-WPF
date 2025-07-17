using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PaymentDAO
    {
        private readonly GeneCareContext _context;
        public PaymentDAO()
        {
            _context = new GeneCareContext();
        }
        public PaymentDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<Payment?> GetPaymentByIdAsync(string paymentId)
        {
            try
            {
                return await _context.Payments.FindAsync(paymentId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the payment.", ex);
            }
        }

        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            try
            {
                return await _context.Payments.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all payment.", ex);
            }
        }

        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            try
            {
                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();
                return payment;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the payment.", ex);
            }
        }

        public async Task<Payment> UpdatePaymentAsync(Payment payment)
        {
            try
            {
                _context.Entry(payment).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return payment;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the payment.", ex);
            }
        }

        public async Task<bool> DeletePaymentAsync(string paymentId)
        {
            try
            {
                var payment = await _context.Payments.FindAsync(paymentId);
                if (payment == null)
                {
                    return false; // Payment not found
                }
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the payment.", ex);
            }
        }
    }
}
