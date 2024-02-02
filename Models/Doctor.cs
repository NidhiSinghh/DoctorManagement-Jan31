using System.ComponentModel.DataAnnotations;

namespace DoctorApplication.Models
{
    /// <summary>
    /// Represents a doctor in the system.
    /// </summary>
    public class Doctor:IEquatable<Doctor>
    {
       
        /// <summary>
        /// Gets or sets the unique identifier for the doctor.
        /// </summary>
        [Key]
        public int DoctorId { get; set; }

        /// <summary>
        /// Gets or sets the name of the doctor.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the age of the doctor.
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// Gets or sets the qualification of the doctor.
        /// </summary>
        public string? Qualification { get; set; }

        /// <summary>
        /// Gets or sets the experience of the doctor in years.
        /// </summary>
        public int? Experience { get; set; }

        /// <summary>
        /// Gets or sets the specialization or speciality of the doctor.
        /// </summary>
        public string? Specialization { get; set; }

        /// <summary>
        /// Initializes a defualt constructor.
        /// </summary>

        ICollection<Appointment> Appointments {  get; set; }

        public Doctor()
        {
            DoctorId = 0;
            Name = string.Empty;
            Age = 0;
            Qualification = string.Empty;
            Experience = 0;
            Specialization = string.Empty;


        }
        /// <summary>
        /// Initializes a parameterized constructor
        /// </summary>
        /// <param name="id">The unique identifier for the doctor.</param>
        /// <param name="name">The name of the doctor.</param>
        /// <param name="age">The age of the doctor.</param>
        /// <param name="qualification">The qualification of the doctor.</param>
        /// <param name="experience">The experience of the doctor in years.</param>
        /// <param name="speciality">The specialization or speciality of the doctor.</param>

        public Doctor(int id, string name, int age, string? qualification, int experience, string? speciality)
        {
            DoctorId = id;
            Name = name;
            Age = age;
            Qualification = qualification ?? "";
            Experience = experience;
            Specialization = speciality ?? "";
        }
        /// <summary>
        /// Determines whether the specified object is equal to the current doctor.
        /// </summary>
        /// <param name="other">The doctor to compare with the current doctor.</param>
        /// <returns>true if the specified doctor is equal to the current doctor; otherwise false.</returns>

        public bool Equals(Doctor? other)
        {
            var doctor = other ?? new Doctor();
            return
               this.DoctorId == other.DoctorId;              
        }



    }
}
