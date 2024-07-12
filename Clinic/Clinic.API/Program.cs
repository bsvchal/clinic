using Clinic.Domain;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Clinic.Domain.Interfaces;
using Clinic.Domain.Repositories;
using Clinic.Application.BackgroundServices;
using Clinic.API.Settings;
using System.Net.Mail;
using System.Net;

namespace Clinic.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var smtp = builder.Configuration
            .GetSection("SmtpSettings")
            .Get<Smtp>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<ClinicDbContext>(
            options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("Local"));
            }
        );
        builder.Services.AddMediatR(
            cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        builder.Services.AddScoped<IUnitOfWork, ClinicUnitOfWork>();
        builder.Services
            .AddScoped<IAppointmentsRepository, AppointmentsRepository>()
            .AddScoped<IDoctorsRepository, DoctorsRepository>()
            .AddScoped<IOfficesRepository, OfficesRepository>()
            .AddScoped<IPatientsRepository, PatientsRepository>()
            .AddScoped<IPhotosRepository, PhotosRepository>()
            .AddScoped<IReceptionistsRepository, ReceptionistsRepository>();
        builder.Services
            .AddFluentEmail(smtp!.FromEmail, smtp.FromName)
            .AddSmtpSender(new SmtpClient(smtp.Host)
            { 
                Port = smtp.Port,
                EnableSsl = true,
                Credentials = new NetworkCredential(smtp.Username, smtp.Password),
            });

        builder.Services.AddMediatR(
            cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        builder.Services.AddHostedService<BirthdayCongratulationsSender>();

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
            
        app.Run();
    }
}