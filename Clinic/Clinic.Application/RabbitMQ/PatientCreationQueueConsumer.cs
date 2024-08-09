using Clinic.Application.RabbitMQ.Contracts;
using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Clinic.Application.RabbitMQ;

public class PatientCreationQueueConsumer : DefaultBasicConsumer
{
    private readonly IModel _channel;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public PatientCreationQueueConsumer(IModel channel, IServiceScopeFactory serviceScopeFactory)
    {
        _channel = channel;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public override void HandleBasicDeliver(
        string consumerTag,
        ulong deliveryTag,
        bool redelivered,
        string exchange,
        string routingKey,
        IBasicProperties properties,
        ReadOnlyMemory<byte> body
    )
    {
        var model = JsonSerializer.Deserialize<PatientCreationModel>(Encoding.UTF8.GetString(body.ToArray()));
        if (model is null)
            return;

        var patient = new Patient
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            MiddleName = model.MiddleName,
            DateOfBirth = model.DateOfBirth,
            AccountId = model.Id,
            Appointments = []
        };
        using var scope = _serviceScopeFactory.CreateScope();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();  
        unitOfWork.PatientsRepository.CreateAsync(patient).Wait();
        unitOfWork.CommitAsync().Wait();

        _channel.BasicAck(deliveryTag, false);
        Console.WriteLine(model);
    }
}
