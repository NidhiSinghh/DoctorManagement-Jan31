using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorApplication.Models
{
    public class Appointment:IEquatable<Appointment>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the appointment.
        /// </summary>
        [Key]
        public int AppointmentId { get; set; }

        /// <summary>
        /// Gets or sets the status of the appointment (e.g., scheduled, canceled, completed).
        /// </summary>
        public string AppointmentStatus { get; set; }

        /// <summary>
        /// Gets or sets the time of the appointment.
        /// </summary>
        public DateTime? AppointmentTime { get; set; }

        /// <summary>
        /// Gets or sets the description of the appointment.
        /// </summary>
        public string? AppointmentDescription { get; set; }

        /// <summary>
        /// Gets or sets the date of the appointment.
        /// </summary>
        public DateTime? AppointmentDate { get; set; }

        /// <summary>
        /// Gets or sets the ID of the patient associated with the appointment.
        /// </summary>
        public int? PatientId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the doctor associated with the appointment.
        /// </summary>
        public int? DoctorId { get; set; }

        /// <summary>
        /// Gets or sets the associated patient object.
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }

        /// <summary>
        /// Gets or sets the associated doctor object.
        /// </summary>
        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }
        /// <summary>
        /// Initializes a default constructor
        /// </summary>
        
        
        public Appointment()
        {
            AppointmentId = 0;
            AppointmentStatus = string.Empty;
            AppointmentTime = DateTime.MinValue;
            AppointmentDescription = string.Empty;
            AppointmentDate = DateTime.MinValue;
           


        }
        /// <summary>
        /// Initializes a parameterized construcotr with specified values
        /// </summary>
        /// <param name="id">The unique identifier for the appointment.</param>
        /// <param name="status">The status of the appointment.</param>
        /// <param name="time">The time of the appointment.</param>
        /// <param name="date">The date of the appointment.</param>

        public Appointment(int id,string status,DateTime time,DateTime date)
        {
            AppointmentId = id;
            AppointmentStatus= status;
            AppointmentTime = time;
            AppointmentDate= date;

        }

        /// <summary>
        /// Determines whether the specified object is equal to the current appointment.
        /// </summary>
        /// <param name="other">The appointment to compare with the current appointment.</param>
        /// <returns>trueif the specified appointment is equal to the current appointment; otherwise, false.</returns>


        public bool Equals(Appointment? other)
        {
            var appointment = other ?? new Appointment();
            return this.AppointmentId == other.AppointmentId;
        }
    }
}
