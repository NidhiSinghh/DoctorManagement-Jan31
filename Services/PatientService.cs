using DoctorApplication.Interfaces;
using DoctorApplication.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoctorApplication.Services
{
    public class PatientService : IPatientAdminService
    {
        private IRepository<int, Patient> _repo;

        public PatientService(IRepository<int, Patient> repo)
        {
            _repo = repo;
        }
        public async Task<Patient> AddPatient(Patient patient)
        {
            patient = await _repo.Add(patient);
            return patient;
        }

        public async Task<Patient> ChangePatientAgeAsync(int id, int age)
        {
            var patient = await _repo.GetAsync(id);
            if (patient != null)
            {
                patient.PatientAge = age;
                patient = await _repo.Update(patient);
                return patient;
            }
            return null;
        }

        public async Task<Patient> ChangePatientDescriptionAsync(int id, string description)
        {
            var patient = await _repo.GetAsync(id);
            if (patient != null)
            {
                patient.PatientDescription=description;
                patient = await _repo.Update(patient);
                return patient;
            }
            return null;
        }

        public async Task<Patient> GetPatient(int id)
        {
            var patient = await _repo.GetAsync(id);
            return patient;
        }

        public async Task<List<Patient>> GetPatientAsync()
        {
            var patients = await _repo.GetAsync();
            return patients;
        }
    }
}
