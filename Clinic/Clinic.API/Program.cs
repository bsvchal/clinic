using Clinic.Domain;
using Clinic.Domain.Interfaces;
using Clinic.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Clinic.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
        });
        builder.Services.AddScoped<IUnitOfWork, AppUnitOfWork>();
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();

        builder.Services.AddScoped<IOfficesRepository, OfficesRepository>();
        builder.Services.AddScoped<IPhotosRepository, PhotosRepository>();

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseExceptionHandler();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Map(
            "/aboba",
            () =>
            {
                throw new NotImplementedException("zaza");
            }
        );

        app.Run();
    }
}
