using DoctorApplication.Interfaces;
using DoctorApplication.Models;
using DoctorApplication.Models.DTO;
using DoctorApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentApplication.Controllers
{
    /// <summary>
    /// Controller for handling Appointment-related requests in the Appointment Application.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentAdminService _adminService;


        public AppointmentController(IAppointmentAdminService adminService)
        {
            _adminService = adminService;
        }

        /// <summary>
        /// Retrieves a list of Appointments.
        /// </summary>
        /// <returns>A list of Appointments.</returns>
        [HttpGet]
        public async Task<List<Appointment>> Get()
        {
            var Appointments = await _adminService.GetAppointmentAsync();
            return Appointments;
        }
        [HttpGet("GetById")]
        public async Task<Appointment> GetAppointments(int id)
        {
            var Appointment = await _adminService.GetAppointment(id);
            return Appointment;
        }

        /// <summary>
        /// Adds a new Appointment.
        /// </summary>
        /// <param name="Appointment">The Appointment to be added.</param>
        /// <returns>The added Appointment.</returns>
        [HttpPost]
        public async Task<Appointment> Post(Appointment Appointment)
        {
            var addedAppointment = await _adminService.AddAppointment(Appointment);
            return addedAppointment;
        }


        [HttpPut]
        public async Task<Appointment> UpdateDate(AppointmentDateDTO AppointmentDto)
        {
            var Appointment = await _adminService.ChangeAppointmentDateAsync(AppointmentDto.Id, AppointmentDto.Date);
            return Appointment;
        }
        [Route("[controller]/ChangeStatus")]
        [HttpPut]
        public async Task<Appointment> UpdateStatus(AppointmentStatusDTO AppointmentDto)
        {
            var Appointment = await _adminService.ChangeAppointmentStatusAsync(AppointmentDto.Id, AppointmentDto.Status);
            return Appointment;
        }
        [Route("[controller]/ChangeTime")]
        [HttpPut]
        public async Task<Appointment> UpdateTime(AppointmentTimeDTO AppointmentDto)
        {
            var Appointment = await _adminService.ChangeAppointmentTimeAsync(AppointmentDto.Id, AppointmentDto.Time);
            return Appointment;
        }
        [Route("[controller]/ChangeDescription")]
        [HttpPut]
        public async Task<Appointment> UpdateDescription(DescriptionDTO DescriptionDto)
        {
            var Appointment = await _adminService.ChangeAppointmentDescriptionAsync(DescriptionDto.Id, DescriptionDto.description);
            return Appointment;
        }
    }
}
