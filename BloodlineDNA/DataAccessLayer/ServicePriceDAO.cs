using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ServicePriceDAO
    {
        private readonly GeneCareContext _context;
        public ServicePriceDAO()
        {
            _context = new GeneCareContext();
        }
        public ServicePriceDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<ServicePrice?> GetServicePriceByIdAsync(int priceId)
        {
            try
            {
                return await _context.ServicePrices.FindAsync(priceId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the service price.", ex);
            }
        }

        public async Task<List<ServicePrice>> GetAllServicePricesAsync()
        {
            try
            {
                return await _context.ServicePrices.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all service price.", ex);
            }
        }

        public async Task<ServicePrice> CreateServicePriceAsync(ServicePrice testResult)
        {
            try
            {
                _context.ServicePrices.Add(testResult);
                await _context.SaveChangesAsync();
                return testResult;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the service price.", ex);
            }
        }

        public async Task<ServicePrice> UpdateServicePriceAsync(ServicePrice testResult)
        {
            try
            {
                _context.Entry(testResult).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return testResult;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the service price.", ex);
            }
        }

        public async Task<bool> DeleteServicePriceAsync(int priceId)
        {
            try
            {
                var testResult = await _context.ServicePrices.FindAsync(priceId);
                if (testResult == null)
                {
                    return false; // Service price not found
                }
                _context.ServicePrices.Remove(testResult);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the service price.", ex);
            }
        }
    }
}
