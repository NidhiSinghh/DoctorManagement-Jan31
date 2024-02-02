using DoctorApplication.Interfaces;
using DoctorApplication.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoctorApplication.Services
{
    public class DoctorService : IDoctorAdminService
    {
        private IRepository<int, Doctor> _repo;

        public DoctorService(IRepository<int, Doctor> repo)
        {
            _repo = repo;
        }
        public async Task<Doctor> AddDoctor(Doctor Doctor)
        {
            Doctor = await _repo.Add(Doctor);
            return Doctor;
        }

        public async Task<Doctor> ChangeDoctorAgeAsync(int id, int age)
        {
            var Doctor = await _repo.GetAsync(id);
            if (Doctor != null)
            {
                Doctor.Age = age;
                Doctor = await _repo.Update(Doctor);
                return Doctor;
            }
            return null;
        }

       

        public async Task<Doctor> ChangeDoctorExperinceAsync(int id, int experience)
        {
            var Doctor = await _repo.GetAsync(id);
            if (Doctor != null)
            {
                Doctor.Experience = experience;
                Doctor = await _repo.Update(Doctor);
                return Doctor;
            }
            return null;
        }

        public async Task<Doctor> ChangeDoctorQualificationAsync(int id, string qualification)
        {
            var Doctor = await _repo.GetAsync(id);
            if (Doctor != null)
            {
                Doctor.Qualification = qualification;
                Doctor = await _repo.Update(Doctor);
                return Doctor;
            }
            return null;
        }

        public async  Task<Doctor> ChangeDoctorSpecializationAsync(int id, string specialization)
        {
            var Doctor = await _repo.GetAsync(id);
            if (Doctor != null)
            {
                Doctor.Specialization = specialization;
                Doctor = await _repo.Update(Doctor);
                return Doctor;
            }
            return null;
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            var Doctor = await _repo.GetAsync(id);
            return Doctor;
        }

        public async Task<List<Doctor>> GetDoctorAsync()
        {
            var Doctors = await _repo.GetAsync();
            return Doctors;
        }
    }
}
