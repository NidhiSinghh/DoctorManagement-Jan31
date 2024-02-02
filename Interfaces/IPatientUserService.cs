using DoctorApplication.Models;

namespace DoctorApplication.Interfaces
{
    public interface IPatientUserService
    {
        public Task<Patient> GetPatient(int id);
    }
}
