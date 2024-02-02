using DoctorApplication.Contexts;
using DoctorApplication.Exceptions;
using DoctorApplication.Interfaces;
using DoctorApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorApplication.Repositories
{
    /// <summary>
    /// Repository class for handling operations related to doctors.
    /// </summary>
    public class DoctorRepository : IRepository<int, Doctor>
    {
        
        readonly RequestTrackerContext _context;
        public DoctorRepository(RequestTrackerContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Adds a new doctor to the repository.
        /// </summary>
        /// <param name="item">The doctor to be added.</param>
        /// <returns>The added doctor entity.</returns>
        public async Task<Doctor> Add(Doctor item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }
       

        public async Task<Doctor> Delete(int key)
        {
            var doctor = await GetAsync(key);
            _context?.Doctors.Remove(doctor);
            return doctor;
        }
        public async Task<Doctor> Update(Doctor item)
        {
            var appointment = await GetAsync(item.DoctorId);
            _context.Entry<Doctor>(item).State = EntityState.Modified;

            _context.SaveChanges();
            return item;
        }






        /// <summary>
        /// Retrieves a list of doctors from the repository.
        /// </summary>
        /// <returns>A list of doctor entities.</returns>
        public async Task<List<Doctor>> GetAsync()
        {
            var doctors = _context.Doctors.ToList();
            return doctors;
        }
        public async Task<Doctor> GetAsync(int key)
        {
            var appointments = await GetAsync();
            var doctorByKey = appointments.FirstOrDefault(a => a.DoctorId == key);
            if (doctorByKey != null)
                return doctorByKey;
            throw new NoSuchDoctorException();
        }



       
    }
}
