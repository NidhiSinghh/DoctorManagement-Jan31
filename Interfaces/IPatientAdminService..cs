using DoctorApplication.Models;

namespace DoctorApplication.Interfaces
{
    /// <summary>
    /// Interface for a repository handling operations related to patients.
    /// </summary>
    /// <typeparam name="K">The type of the key used to identify patients.</typeparam>
    /// <typeparam name="T">The type of the patient entity.</typeparam>
    public interface IPatientAdminService:IPatientUserService
    {
        /// <summary>
        /// Adds a new patient to the repository.
        /// </summary>
        /// <param name="item">The patient to be added.</param>
        /// <returns>The added patient entity.</returns>
        Task<Patient> AddPatient(Patient patient);

        /// <summary>
        /// Retrieves a list of patients from the repository.
        /// </summary>
        /// <returns>A list of patient entities.</returns>
        public Task<List<Patient>> GetPatientAsync();

        public Task<Patient> ChangePatientAgeAsync(int id, int age);
        public Task<Patient> ChangePatientDescriptionAsync(int id, string description);
    }
}
