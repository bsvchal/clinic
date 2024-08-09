using IdentityServer.Infrastructure.Contracts;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace IdentityServer.Infrastructure;

public class RabbitMQMessageSender : IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMQMessageSender()
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
    }

    public void Send(PatientCreationModel model)
    {
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(model));
        var basicProperties = _channel.CreateBasicProperties();
        basicProperties.Persistent = true;

        _channel.BasicPublish(
            exchange: "",
            routingKey: "patients_to_create",
            basicProperties: basicProperties,
            body: body
        );
    }

    public void Dispose()
    {
        _channel.Close(); 
        _connection.Close();
    }
}
