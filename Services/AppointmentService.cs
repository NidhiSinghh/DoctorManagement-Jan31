using DoctorApplication.Interfaces;
using DoctorApplication.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.NetworkInformation;

namespace DoctorApplication.Services
{
    public class AppointmentService : IAppointmentAdminService
    {
        private IRepository<int, Appointment> _repo;

        public AppointmentService(IRepository<int, Appointment> repo)
        {
            _repo = repo;
        }
        public async Task<Appointment> AddAppointment(Appointment Appointment)
        {
            Appointment = await _repo.Add(Appointment);
            return Appointment;
        }

       

        public async Task<Appointment> ChangeAppointmentDateAsync(int id, DateTime date)
        {
            var Appointment = await _repo.GetAsync(id);
            if (Appointment != null)
            {
                Appointment.AppointmentDate = date;
                Appointment = await _repo.Update(Appointment);
                return Appointment;
            }
            return null;
        }

        public async Task<Appointment> ChangeAppointmentDescriptionAsync(int id, string description)
        {
            var Appointment = await _repo.GetAsync(id);
            if (Appointment != null)
            {
                Appointment.AppointmentDescription=description;
                Appointment = await _repo.Update(Appointment);
                return Appointment;
            }
            return null;
        }

        public async Task<Appointment> ChangeAppointmentStatusAsync(int id, string status)
        {
            var Appointment = await _repo.GetAsync(id);
            if (Appointment != null)
            {
                Appointment.AppointmentStatus = status;
                Appointment = await _repo.Update(Appointment);
                return Appointment;
            }
            return null;
        }

        public async Task<Appointment> ChangeAppointmentTimeAsync(int id, DateTime time)
        {
            var Appointment = await _repo.GetAsync(id);
            if (Appointment != null)
            {
                Appointment.AppointmentTime = time;
                Appointment = await _repo.Update(Appointment);
                return Appointment;
            }
            return null;
        }

        public async Task<Appointment> GetAppointment(int id)
        {
            var Appointment = await _repo.GetAsync(id);
            return Appointment;
        }

        public async Task<List<Appointment>> GetAppointmentAsync()
        {
            var Appointments = await _repo.GetAsync();
            return Appointments;
        }

       
    }
}
