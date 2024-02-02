using DoctorApplication.Models;

namespace DoctorApplication.Interfaces
{
    public interface IAppointmentUserService
    {
        public Task<Appointment> GetAppointment(int id);

    }
}