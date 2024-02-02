using DoctorApplication.Models;

namespace DoctorApplication.Interfaces
{
    /// <summary>
    /// Interface for a repository handling operations related to Doctors.
    /// </summary>
    /// <typeparam name="K">The type of the key used to identify Doctors.</typeparam>
    /// <typeparam name="T">The type of the Doctor entity.</typeparam>
    public interface IDoctorAdminService:IDoctorUserService
    {
        /// <summary>
        /// Adds a new Doctor to the repository.
        /// </summary>
        /// <param name="item">The Doctor to be added.</param>
        /// <returns>The added Doctor entity.</returns>
        Task<Doctor> AddDoctor(Doctor Doctor);

        /// <summary>
        /// Retrieves a list of Doctors from the repository.
        /// </summary>
        /// <returns>A list of Doctor entities.</returns>
        public Task<List<Doctor>> GetDoctorAsync();

        public Task<Doctor> ChangeDoctorAgeAsync(int id, int age);
        public Task<Doctor> ChangeDoctorExperinceAsync(int id, int experience);
        public Task<Doctor> ChangeDoctorQualificationAsync(int id, string qualification);
        public Task<Doctor> ChangeDoctorSpecializationAsync(int id, string specialization);
    }
}
