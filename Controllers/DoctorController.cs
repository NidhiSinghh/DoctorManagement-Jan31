using DoctorApplication.Interfaces;
using DoctorApplication.Models;
using DoctorApplication.Models.DTO;
using DoctorApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DoctorApplication.Controllers
{
    /// <summary>
    /// Controller for handling Doctor-related requests in the Doctor Application.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        private readonly IDoctorAdminService _adminService;


        public DoctorController(IDoctorAdminService adminService)
        {
            _adminService = adminService;
        }

        /// <summary>
        /// Retrieves a list of Doctors.
        /// </summary>
        /// <returns>A list of Doctors.</returns>
        [HttpGet]
        public async Task<List<Doctor>> Get()
        {
            var Doctors = await _adminService.GetDoctorAsync();
            return Doctors;
        }
        [HttpGet("GetById")]
        public async Task<Doctor> GetDoctors(int id)
        {
            var Doctor = await _adminService.GetDoctor(id);
            return Doctor;
        }

        /// <summary>
        /// Adds a new Doctor.
        /// </summary>
        /// <param name="Doctor">The Doctor to be added.</param>
        /// <returns>The added Doctor.</returns>
        [HttpPost]
        public async Task<Doctor> Post(Doctor Doctor)
        {
            var addedDoctor = await _adminService.AddDoctor(Doctor);
            return addedDoctor;
        }

        [HttpPut]
        public async Task<Doctor> UpdateAge(AgeDTO DoctorDto)
        {
            var Doctor = await _adminService.ChangeDoctorAgeAsync(DoctorDto.Id, DoctorDto.Age);
            return Doctor;
        }
        [Route("[controller]/ChangeExperience")]
        [HttpPut]
        public async Task<Doctor> UpdateExperince(DoctorExperienceDTO DoctorDto)
        {
            var Doctor = await _adminService.ChangeDoctorExperinceAsync(DoctorDto.Id, DoctorDto.Experience);
            return Doctor;
        }
        [Route("[controller]/ChangeQualification")]
        [HttpPut]
        public async Task<Doctor> UpdateQualification(DoctorQualificationDTO DoctorDto)
        {
            var Doctor = await _adminService.ChangeDoctorQualificationAsync(DoctorDto.Id, DoctorDto.Qualification);
            return Doctor;
        }
        [Route("[controller]/ChangeSpecialization")]
        [HttpPut]
        public async Task<Doctor> UpdateSpecialization(DoctorSpecializationDTO DoctorDto)
        {
            var Doctor = await _adminService.ChangeDoctorSpecializationAsync(DoctorDto.Id, DoctorDto.Specialization);
            return Doctor;
        }
    }
}
