using Clinic.Domain;
using Microsoft.EntityFrameworkCore;
using Clinic.Domain.Interfaces;
using Clinic.Domain.Repositories;
using Clinic.Application;

namespace Clinic.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

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
        builder.Services.AddScoped<IUnitOfWork, ClinicUnitOfWork>();
        builder.Services
            .AddScoped<IAccountsRepository, AccountsRepository>()
            .AddScoped<IAppointmentsRepository, AppointmentsRepository>()
            .AddScoped<IDoctorsRepository, DoctorsRepository>()
            .AddScoped<IOfficesRepository, OfficesRepository>()
            .AddScoped<IPatientsRepository, PatientsRepository>()
            .AddScoped<IPhotosRepository, PhotosRepository>()
            .AddScoped<IReceptionistsRepository, ReceptionistsRepository>();

        builder.Services.AddApplication();

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