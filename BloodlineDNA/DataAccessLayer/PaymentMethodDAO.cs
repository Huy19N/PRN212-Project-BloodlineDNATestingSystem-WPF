using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PaymentMethodDAO
    {
        private readonly GeneCareContext _context;
        public PaymentMethodDAO()
        {
            _context = new GeneCareContext();
        }
        public PaymentMethodDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<PaymentMethod?> GetPaymentMethodByIdAsync(int paymentMethodId)
        {
            try
            {
                return await _context.PaymentMethods.FindAsync(paymentMethodId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the payment method.", ex);
            }
        }

        public async Task<List<PaymentMethod>> GetAllPaymentMethodsAsync()
        {
            try
            {
                return await _context.PaymentMethods.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all payment method.", ex);
            }
        }

        public async Task<PaymentMethod> CreatePaymentMethodAsync(PaymentMethod paymentMethod)
        {
            try
            {
                _context.PaymentMethods.Add(paymentMethod);
                await _context.SaveChangesAsync();
                return paymentMethod;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the payment method.", ex);
            }
        }

        public async Task<PaymentMethod> UpdatePaymentMethodAsync(PaymentMethod paymentMethod)
        {
            try
            {
                _context.Entry(paymentMethod).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return paymentMethod;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the payment method.", ex);
            }
        }

        public async Task<bool> DeletePaymentMethodAsync(int paymentMethodId)
        {
            try
            {
                var paymentMethod = await _context.PaymentMethods.FindAsync(paymentMethodId);
                if (paymentMethod == null)
                {
                    return false; // Payment method not found
                }
                _context.PaymentMethods.Remove(paymentMethod);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the payment method.", ex);
            }
        }
    }
}
