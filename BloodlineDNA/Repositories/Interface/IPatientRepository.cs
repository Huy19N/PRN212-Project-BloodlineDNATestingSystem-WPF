using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories.Interface
{
    public interface IPatientRepository
    {
        public List<Patient> GetAllPatients();
        public Patient GetPatientById(int id);
        public bool AddPatient(Patient patient);
        public bool DeletePatient(Patient patient);
        public bool UpdatePatient(Patient patient);
        public List<Patient> GetPatientsByBookingId(int bookingId);
        public List<Patient> GetPatientsBySampleId(int sampleId);
    }
}
