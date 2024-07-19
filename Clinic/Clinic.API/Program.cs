using Clinic.Domain;
using Clinic.Domain.Interfaces;
using Clinic.Domain.Repositories;
using Elastic.Serilog.Sinks;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Exceptions;
using System.Reflection;
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

        builder.Services.AddMediatR(
            cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();
        builder.Services.AddApplication();

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