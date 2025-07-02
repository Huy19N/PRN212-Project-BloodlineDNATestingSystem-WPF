using BusinessObjects;

namespace DataAccessLayer;

public class PatientDAO
{
    public List<Patient> GetAllPatients()
    {
        using var context = new GeneCareContext();
        return context.Patients.ToList();
    }
    public bool CreatePatient(Patient patient)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (patient == null)
            {
                return false;
            }
            context.Patients.Add(new Patient
            {
                BookingId = patient.BookingId,
                FullName = patient.FullName,
                BirthDate = patient.BirthDate,
                Gender = patient.Gender,
                IdentifyId = patient.IdentifyId,
                SampleType = patient.SampleType,
                HasTestedDna = patient.HasTestedDna,
                Relationship = patient.Relationship
            });

            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
    public bool UpdatePatient(Patient patient)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (patient == null)
            {
                return false;
            }

            var existingPatient = context.Patients.Find(patient.PatientId);
            if (existingPatient == null)
            {
                return false;
            }
            existingPatient.BookingId = patient.BookingId;
            existingPatient.FullName = patient.FullName;
            existingPatient.BirthDate = patient.BirthDate;
            existingPatient.Gender = patient.Gender;
            existingPatient.IdentifyId = patient.IdentifyId;
            existingPatient.SampleType = patient.SampleType;
            existingPatient.HasTestedDna = patient.HasTestedDna;
            existingPatient.Relationship = patient.Relationship;

            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
    public bool DeletePatientById(int id)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            var patient = context.Patients.Find(id);
            if (patient == null) return false;
            context.Patients.Remove(patient);

            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
}
