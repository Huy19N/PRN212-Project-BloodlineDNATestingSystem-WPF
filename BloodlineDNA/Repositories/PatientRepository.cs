using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class PatientRepository : Interface.IPatientRepository
    {
        PatientDAO patientDAO = new PatientDAO();
        public bool AddPatient(Patient patient)
        {
            return patientDAO.AddPatient(patient);
        }

        public bool DeletePatient(Patient patient)
        {
            return patientDAO.DeletePatient(patient);
        }

        public List<Patient> GetAllPatients()
        {
            return patientDAO.GetAllPatients();
        }

        public Patient GetPatientById(int id)
        {
            return patientDAO.GetPatientById(id);
        }

        public List<Patient> GetPatientsByBookingId(int bookingId)
        {
            return patientDAO.GetPatientsByBookingId(bookingId);
        }

        public List<Patient> GetPatientsBySampleId(int sampleId)
        {
            return patientDAO.GetPatientsBySampleId(sampleId);
        }

        public bool UpdatePatient(Patient patient)
        {
            return patientDAO.UpdatePatient(patient);
        }
    }
}
