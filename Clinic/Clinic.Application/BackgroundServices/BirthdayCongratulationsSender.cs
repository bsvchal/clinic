using Clinic.Domain.Interfaces;
using FluentEmail.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;

namespace Clinic.Application.BackgroundServices;

public class BirthdayCongratulationsSender : BackgroundService
{
    private readonly IFluentEmailFactory _fluentEmailFactory;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public BirthdayCongratulationsSender(
        IFluentEmailFactory fluentEmailFactory, IServiceScopeFactory serviceScopeFactory
    )
    {
        _fluentEmailFactory = fluentEmailFactory;
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        /*while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            var doctors = await unitOfWork.DoctorsRepository
                .GetAsync(cancellationToken: stoppingToken);
            var patients = await unitOfWork.PatientsRepository
                .GetAsync(cancellationToken: stoppingToken);

            var peopleToSendCongratulationsTo = doctors
                .Where(d => d.DateOfBirth.Day == DateTime.Now.Day && d.DateOfBirth.Month == DateTime.Now.Month)
                .Select(d => new { d.Account.Email, d.FirstName, d.LastName, d.MiddleName })
                .Union(
                    patients
                        .Where(p => p.DateOfBirth.Day == DateTime.Now.Day && p.DateOfBirth.Month == DateTime.Now.Month)
                        .Select(p => new { p.Account.Email, p.FirstName, p.LastName, p.MiddleName })
                );

            foreach (var person in peopleToSendCongratulationsTo)
            {
                _fluentEmailFactory
                    .Create()
                    .To(person.Email)
                    .Subject("Our congratulations!")
                    .Body(
                        new StringBuilder()
                            .AppendLine($"Dear {person.FirstName} {person.MiddleName} {person.LastName}!")
                            .AppendLine("hb !!!")
                            .ToString()
                    )
                    .Send();
            }
            
            await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
        }*/
    }
}
