using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PaymentReturnLogDAO
    {
        private readonly GeneCareContext _context;
        public PaymentReturnLogDAO()
        {
            _context = new GeneCareContext();
        }
        public PaymentReturnLogDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<PaymentReturnLog?> GetPaymentReturnLogByIdAsync(int returnLogId)
        {
            try
            {
                return await _context.PaymentReturnLogs.FindAsync(returnLogId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the payment return log.", ex);
            }
        }

        public async Task<List<PaymentReturnLog>> GetAllPaymentReturnLogsAsync()
        {
            try
            {
                return await _context.PaymentReturnLogs.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all payment return log.", ex);
            }
        }

        public async Task<PaymentReturnLog> CreatePaymentReturnLogAsync(PaymentReturnLog paymentReturnLog)
        {
            try
            {
                _context.PaymentReturnLogs.Add(paymentReturnLog);
                await _context.SaveChangesAsync();
                return paymentReturnLog;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the payment return log.", ex);
            }
        }

        public async Task<PaymentReturnLog> UpdatePaymentReturnLogAsync(PaymentReturnLog paymentReturnLog)
        {
            try
            {
                _context.Entry(paymentReturnLog).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return paymentReturnLog;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the payment return log.", ex);
            }
        }

        public async Task<bool> DeletePaymentReturnLogAsync(int returnLogId)
        {
            try
            {
                var paymentReturnLog = await _context.PaymentReturnLogs.FindAsync(returnLogId);
                if (paymentReturnLog == null)
                {
                    return false; // Payment return log not found
                }
                _context.PaymentReturnLogs.Remove(paymentReturnLog);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the payment return log.", ex);
            }
        }
    }
}
