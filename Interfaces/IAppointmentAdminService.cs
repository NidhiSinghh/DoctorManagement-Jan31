using DoctorApplication.Models;

namespace DoctorApplication.Interfaces
{
    /// <summary>
    /// Interface for a repository handling operations related to Appointments.
    /// </summary>
    /// <typeparam name="K">The type of the key used to identify Appointments.</typeparam>
    /// <typeparam name="T">The type of the Appointment entity.</typeparam>
    public interface IAppointmentAdminService:IAppointmentUserService
    {
        /// <summary>
        /// Adds a new Appointment to the repository.
        /// </summary>
        /// <param name="item">The Appointment to be added.</param>
        /// <returns>The added Appointment entity.</returns>
        Task<Appointment> AddAppointment(Appointment Appointment);

        /// <summary>
        /// Retrieves a list of Appointments from the repository.
        /// </summary>
        /// <returns>A list of Appointment entities.</returns>
        public Task<List<Appointment>> GetAppointmentAsync();

        public Task<Appointment> ChangeAppointmentDateAsync(int id, DateTime date);
        public Task<Appointment> ChangeAppointmentDescriptionAsync(int id, string description);
        public Task<Appointment> ChangeAppointmentTimeAsync(int id, DateTime time);
        public Task<Appointment> ChangeAppointmentStatusAsync(int id, string status);
    }
}
