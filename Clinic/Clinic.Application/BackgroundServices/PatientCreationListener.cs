using Clinic.Application.RabbitMQ;
using Clinic.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

namespace Clinic.Application.BackgroundServices;

public class PatientCreationListener : BackgroundService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public PatientCreationListener(IServiceScopeFactory serviceScopeFactory)
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(
            queue: "patients_to_create",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        var consumer = new PatientCreationQueueConsumer(_channel, _serviceScopeFactory);
        _channel.BasicConsume("patients_to_create", false, consumer);

        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel.Close();
        _connection.Close();

        base.Dispose();
    }
}
