using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class PatientDAO
    {
        GeneCarePrnContext context = new GeneCarePrnContext();
        public List<Patient> GetAllPatients()
        {
            return context.Patients.ToList();
        }
        public Patient GetPatientById(int id)
        {
            return context.Patients.FirstOrDefault(p => p.PatientId == id);
        }
        public bool AddPatient(Patient patient)
        {
            context.Patients.Add(patient);
            return context.SaveChanges() > 0;
        }
        public bool DeletePatient(Patient patient)
        {
            context.Patients.Remove(patient);
            return context.SaveChanges() > 0;
        }
        public bool UpdatePatient(Patient patient)
        {
            context.Patients.Update(patient);
            return context.SaveChanges() > 0;
        }

        public List<Patient> GetPatientsByBookingId(int bookingId)
        {
            return context.Patients
                .Where(b => b.BookingId == bookingId)
                .ToList();
        }

        public List<Patient> GetPatientsBySampleId(int sampleId)
        {
            return context.Patients
                .Where(p => p.SampleId == sampleId)
                .ToList();
        }
    }
}
