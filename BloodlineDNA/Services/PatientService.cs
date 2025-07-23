using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;
using Repositories.Interface;

namespace Services
{
    public class PatientService : Interface.IPatientService
    {
        IPatientRepository patientRepository;

        public PatientService()
        {
            patientRepository = new PatientRepository();
        }
        public bool AddPatient(Patient patient)
        {
            return patientRepository.AddPatient(patient);
        }

        public bool DeletePatient(Patient patient)
        {
            return patientRepository.DeletePatient(patient);
        }

        public List<Patient> GetAllPatients()
        {
            return patientRepository.GetAllPatients();
        }

        public Patient GetPatientById(int id)
        {
            return patientRepository.GetPatientById(id);
        }

        public List<Patient> GetPatientsByBookingId(int bookingId)
        {
            return patientRepository.GetPatientsByBookingId(bookingId);
        }

        public List<Patient> GetPatientsBySampleId(int sampleId)
        {
            return patientRepository.GetPatientsBySampleId(sampleId);
        }

        public bool UpdatePatient(Patient patient)
        {
            return patientRepository.UpdatePatient(patient);
        }
    }
}
