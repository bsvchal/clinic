using Clinic.API.Settings;
using Clinic.Application;
using Clinic.Application.BackgroundServices;
using Clinic.Domain;
using Clinic.Domain.Interfaces;
using Clinic.Domain.Repositories;
using Elastic.Serilog.Sinks;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Exceptions;
using System.Net;
using System.Net.Mail;

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

        Log.Logger = new LoggerConfiguration()
            .Enrich.WithExceptionDetails()
            .WriteTo.Elasticsearch(
                [new Uri(builder.Configuration["ElasticUri"]!)],
                options =>
                {
                    options.BootstrapMethod = 
                        Elastic.Ingest.Elasticsearch.BootstrapMethod.Failure;
                    options.DataStream = 
                        new Elastic.Ingest.Elasticsearch.DataStreams.DataStreamName("Logs", "Clinic");
                }
            )
            .CreateLogger();

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
        builder.Services
            .AddFluentEmail(smtp!.FromEmail, smtp.FromName)
            .AddSmtpSender(new SmtpClient(smtp.Host)
            { 
                Port = smtp.Port,
                EnableSsl = true,
                Credentials = new NetworkCredential(smtp.Username, smtp.Password),
            });

        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();
        builder.Services.AddApplication();

        builder.Services.AddHostedService<BirthdayCongratulationsSender>();

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseExceptionHandler();
        app.MapControllers();
            
        app.Run();
    }
}