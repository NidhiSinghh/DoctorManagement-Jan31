using System;
using System.ComponentModel.DataAnnotations;

namespace DoctorApplication.Models
{
    /// <summary>
    /// Represents a patient in the system.
    /// </summary>
    public class Patient : IEquatable<Patient>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the patient.
        /// </summary>
        [Key]
        public int PatientId { get; set; }

        /// <summary>
        /// Gets or sets the name of the patient.
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// Gets or sets the description of the patient.
        /// </summary>
        public string PatientDescription { get; set; }

        /// <summary>
        /// Gets or sets the age of the patient.
        /// </summary>
        public int PatientAge { get; set; }

        /// <summary>
        /// Initializes a default constructor
        /// </summary>
        public Patient()
        {
            PatientId = 0;
            PatientAge = 0;
            PatientName = string.Empty;
            PatientDescription = string.Empty;
        }

        /// <summary>
        /// Initializes a parameterized construcor
        /// </summary>
        /// <param name="id">The unique identifier for the patient.</param>
        /// <param name="age">The age of the patient.</param>
        /// <param name="name">The name of the patient.</param>
        /// <param name="desc">The description of the patient.</param>
        public Patient(int id, int age, string name, string desc)
        {
            PatientId = id;
            PatientName = name;
            PatientDescription = desc;
            PatientAge = age;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current patient.
        /// </summary>
        /// <param name="other">The patient to compare with the current patient.</param>
        /// <returns>true if the specified patient is equal to the current patient; otherwise, false.</returns>
        public bool Equals(Patient? other)
        {
            var patient = other ?? new Patient();

            return this.PatientId == other.PatientId;
        }
    }
}
