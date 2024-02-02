using DoctorApplication.Contexts;
using DoctorApplication.Exceptions;
using DoctorApplication.Interfaces;
using DoctorApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorApplication.Repositories
{
    /// <summary>
    /// Repository class for handling operations related to patients.
    /// </summary>
    public class PatientRepository : IRepository<int, Patient>
    {
        readonly RequestTrackerContext _context;
        public PatientRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        

        /// <summary>
        /// Adds a new patient to the repository.
        /// </summary>
        /// <param name="item">The patient to be added.</param>
        /// <returns>The added patient entity.</returns>
        public async Task<Patient> Add(Patient item)
        {
            _context.Patients.Add(item);
            _context.SaveChanges();
            return item;
        }

        public async Task<Patient> Delete(int key)
        {
            var patient = await GetAsync(key);
            _context?.Patients.Remove(patient);
            return patient;
        }

        public async Task<Patient> GetAsync(int key)
        {
            var patients = await GetAsync();
            var patienntByKey = patients.FirstOrDefault(a => a.PatientId == key);
            if (patienntByKey != null)
                return patienntByKey;
            throw new NoSuchPatientException();
        }
       

        /// <summary>
        /// Retrieves a list of patients from the repository.
        /// </summary>
        /// <returns>A list of patient entities.</returns>
        public async Task<List<Patient>> GetAsync()
        {
            var patients = _context.Patients.ToList();
            return patients;
        }

        public async Task<Patient> Update(Patient item)
        {
            var patient = await GetAsync(item.PatientId);
            _context.Entry<Patient>(item).State = EntityState.Modified;

            _context.SaveChanges();
            return item;
        }

       

    }
}
