using DoctorApplication.Contexts;
using DoctorApplication.Interfaces;
using DoctorApplication.Models;
using DoctorApplication.Repositories;
using DoctorApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace DoctorApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<RequestTrackerContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("requestTrackerConnection"));
            });

            builder.Services.AddScoped<IRepository<int, Doctor>, DoctorRepository>();
            builder.Services.AddScoped<IRepository<int, Patient>, PatientRepository>();
            builder.Services.AddScoped<IRepository<int, Appointment>, AppointmentRepository>();

            builder.Services.AddScoped<IPatientUserService, PatientService>();
            builder.Services.AddScoped<IPatientAdminService, PatientService>();

            builder.Services.AddScoped<IDoctorUserService, DoctorService>();
            builder.Services.AddScoped<IDoctorAdminService, DoctorService>();

            builder.Services.AddScoped<IAppointmentUserService, AppointmentService>();
            builder.Services.AddScoped<IAppointmentAdminService, AppointmentService>();
            //builder.Services.AddScoped<IEmployeeAdminService, EmployeeService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
