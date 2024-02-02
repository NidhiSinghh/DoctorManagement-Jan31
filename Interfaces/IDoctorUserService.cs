using DoctorApplication.Models;

namespace DoctorApplication.Interfaces
{
    public interface IDoctorUserService
    {
        public Task<Doctor> GetDoctor(int id);
    }
}
