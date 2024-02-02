using DoctorApplication.Contexts;
using DoctorApplication.Exceptions;
using DoctorApplication.Interfaces;
using DoctorApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorApplication.Repositories
{
    /// <summary>
    /// Repository class for handling operations related to appointments.
    /// </summary>
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        readonly RequestTrackerContext _context;
        public AppointmentRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new appointment to the repository.
        /// </summary>
        /// <param name="item">The appointment to be added.</param>
        /// <returns>The added appointment entity.</returns>
        public async Task<Appointment> Add(Appointment item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public async Task<Appointment> Delete(int key)
        {
            var appointment = await GetAsync(key);
            _context?.Appointments.Remove(appointment);
            return appointment;
        }

        /// <summary>
        /// Retrieves a list of appointments from the repository, including associated patient and doctor information.
        /// </summary>
        /// <returns>A list of appointment entities.</returns>
        public async Task<List<Appointment>> GetAsync()
        {
            var appointments = _context.Appointments.Include(a => a.Patient).Include(a => a.Doctor).ToList();
            return appointments;
        }

        public async Task<Appointment> GetAsync(int key)
        {
            var appointments = await GetAsync();
            var appointmentByKey = appointments.FirstOrDefault(a => a.AppointmentId == key);
            if (appointmentByKey != null)
                return appointmentByKey;
            throw new NoSuchAppointmentException();
        }

        

        public async Task<Appointment> Update(Appointment item)
        {
            var appointment = await GetAsync(item.AppointmentId);
            _context.Entry<Appointment>(item).State = EntityState.Modified;
            
            _context.SaveChanges();
            return item;
        }
    }
}
