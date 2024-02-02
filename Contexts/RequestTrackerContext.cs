using DoctorApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorApplication.Contexts
{
    /// <summary>
    /// Represents the database context for the Doctor Application
    /// </summary>
    public class RequestTrackerContext : DbContext
    {
        /// <summary>
        /// Initializes a default constructor
        /// </summary>
        public RequestTrackerContext(DbContextOptions options):base(options)
        {
            
        }

        /// <summary>
        /// Configures the database connection and other options for the context.
        /// </summary>
        /// <param name="optionsBuilder">The options builder used to configure the context.</param>
        
        
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
            
        //    optionsBuilder.UseSqlServer(@"Data source=DESKTOP-SRQUN8T;Integrated Security=true;Initial catalog=doctorJan30");
        //}

        /// <summary>
        /// Gets or sets the DbSet for Doctors,allowing access to Doctor entities in the database.
        /// </summary>
        public DbSet<Doctor> Doctors { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for Patients,allowing access to Patient entities in the database.
        /// </summary>
        public DbSet<Patient> Patients { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for Appointments,allowing access to Appointment entities in the database.
        /// </summary>
        public DbSet<Appointment> Appointments { get; set; }
    }
}
