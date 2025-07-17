using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ServiceDAO
    {
        private readonly GeneCareContext _context;
        public ServiceDAO()
        {
            _context = new GeneCareContext();
        }
        public ServiceDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<Service?> GetServiceByIdAsync(int serviceId)
        {
            try
            {
                return await _context.Services.FindAsync(serviceId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the service.", ex);
            }
        }

        public async Task<List<Service>> GetAllServicesAsync()
        {
            try
            {
                return await _context.Services.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all service.", ex);
            }
        }

        public async Task<Service> CreateServiceAsync(Service service)
        {
            try
            {
                _context.Services.Add(service);
                await _context.SaveChangesAsync();
                return service;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the service.", ex);
            }
        }

        public async Task<Service> UpdateServiceAsync(Service service)
        {
            try
            {
                _context.Entry(service).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return service;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the service.", ex);
            }
        }

        public async Task<bool> DeleteServiceAsync(int serviceId)
        {
            try
            {
                var service = await _context.Services.FindAsync(serviceId);
                if (service == null)
                {
                    return false; // Service not found
                }
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the service.", ex);
            }
        }
    }
}
