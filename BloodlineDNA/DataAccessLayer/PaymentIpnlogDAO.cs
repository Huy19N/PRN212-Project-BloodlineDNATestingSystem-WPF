using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PaymentIpnlogDAO
    {
        private readonly GeneCareContext _context;
        public PaymentIpnlogDAO()
        {
            _context = new GeneCareContext();
        }
        public PaymentIpnlogDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<PaymentIpnlog?> GetPaymentIpnlogByIdAsync(int ipnLogId)
        {
            try
            {
                return await _context.PaymentIpnlogs.FindAsync(ipnLogId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the payment IPN log.", ex);
            }
        }

        public async Task<List<PaymentIpnlog>> GetAllPaymentIpnlogsAsync()
        {
            try
            {
                return await _context.PaymentIpnlogs.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all payment IPN log.", ex);
            }
        }

        public async Task<PaymentIpnlog> CreatePaymentIpnlogAsync(PaymentIpnlog paymentIpnlog)
        {
            try
            {
                _context.PaymentIpnlogs.Add(paymentIpnlog);
                await _context.SaveChangesAsync();
                return paymentIpnlog;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the payment IPN log.", ex);
            }
        }

        public async Task<PaymentIpnlog> UpdatePaymentIpnlogAsync(PaymentIpnlog paymentIpnlog)
        {
            try
            {
                _context.Entry(paymentIpnlog).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return paymentIpnlog;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the payment IPN log.", ex);
            }
        }

        public async Task<bool> DeletePaymentIpnlogAsync(int ipnLogId)
        {
            try
            {
                var paymentIpnlog = await _context.PaymentIpnlogs.FindAsync(ipnLogId);
                if (paymentIpnlog == null)
                {
                    return false; // Payment IPN log not found
                }
                _context.PaymentIpnlogs.Remove(paymentIpnlog);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the payment IPN log.", ex);
            }
        }
    }
}
