using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PatientDAO
    {
        private readonly GeneCareContext _context;
        public PatientDAO()
        {
            _context = new GeneCareContext();
        }
        public PatientDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<Patient?> GetPatientByIdAsync(int patientId)
        {
            try
            {
                return await _context.Patients.FindAsync(patientId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the patient.", ex);
            }
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            try
            {
                return await _context.Patients.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all patient.", ex);
            }
        }

        public async Task<Patient> CreatePatientAsync(Patient patient)
        {
            try
            {
                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();
                return patient;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the patient.", ex);
            }
        }

        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            try
            {
                _context.Entry(patient).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return patient;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the patient.", ex);
            }
        }

        public async Task<bool> DeletePatientAsync(int patientId)
        {
            try
            {
                var patient = await _context.Patients.FindAsync(patientId);
                if (patient == null)
                {
                    return false; // Patient not found
                }
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the patient.", ex);
            }
        }
    }
}
