using iNUPCO.SHO.DTOs.Global;
using RabbitMQ.Client;
using System.Text;
using Microsoft.Extensions.Options;

namespace iNUPCO.SHO.Service.RabbitMQSrervice
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly string _queueName;
        private readonly string _exchangeName;
        private readonly string _routingKey;
        private readonly ConnectionFactory _connectionFactory;

        public RabbitMQService(IOptions<RabbitMQSettings> options)
        {
            var settings = options.Value;

            _queueName = settings.QueueName;
            _exchangeName = settings.ExchangeName;
            _routingKey = settings.RoutingKey;

            _connectionFactory = new ConnectionFactory
            {
                HostName = settings.HostName,
                UserName = settings.UserName,
                Password = settings.Password,
                Port = 5672
            };
        }
        public async Task NotifyPOAsync(int SHOID)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            // Declare exchange and queue
            await channel.ExchangeDeclareAsync(_exchangeName, ExchangeType.Direct, durable: true);
            await channel.QueueDeclareAsync(_queueName, durable: true, exclusive: false, autoDelete: false);
            await channel.QueueBindAsync(_queueName, _exchangeName, _routingKey);

            // Publish message
            var body = Encoding.UTF8.GetBytes(SHOID.ToString());
            await channel.BasicPublishAsync(exchange: _exchangeName, routingKey: _routingKey, body: body);
        }
    }
}
