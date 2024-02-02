using DoctorApplication.Interfaces;
using DoctorApplication.Models;
using DoctorApplication.Models.DTO;
using DoctorApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DoctorApplication.Controllers
{
    /// <summary>
    /// Controller for handling patient-related requests in the Doctor Application.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly IPatientAdminService _adminService;

        
        public PatientController(IPatientAdminService adminService)
        {
            _adminService = adminService;
        }

        /// <summary>
        /// Retrieves a list of patients.
        /// </summary>
        /// <returns>A list of patients.</returns>
        [HttpGet]
        public async Task<List<Patient>> Get()
        {
            var patients = await _adminService.GetPatientAsync();
            return patients;
        }
        [HttpGet("GetById")]
        public async Task<Patient> GetPatients(int id)
        {
            var patient = await _adminService.GetPatient(id);
            return patient;
        }

        /// <summary>
        /// Adds a new patient.
        /// </summary>
        /// <param name="patient">The patient to be added.</param>
        /// <returns>The added patient.</returns>
        [HttpPost]
        public async Task<Patient> Post(Patient patient)
        {
            var addedPatient = await _adminService.AddPatient(patient);
            return addedPatient;
        }
        
        [HttpPut]
        public async Task<Patient> UpdateAge(AgeDTO PatientDto)
        {
            var Patient = await _adminService.ChangePatientAgeAsync(PatientDto.Id, PatientDto.Age);
            return Patient;
        }
        [Route("[controller]/ChangeDescription")]
        [HttpPut]
        public async Task<Patient> UpdateDescription(DescriptionDTO PatientDto)
        {
            var Patient = await _adminService.ChangePatientDescriptionAsync(PatientDto.Id, PatientDto.description);
            return Patient;
        }
    }
}
