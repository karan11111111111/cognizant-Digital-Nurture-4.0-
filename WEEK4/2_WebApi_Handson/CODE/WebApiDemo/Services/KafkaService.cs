using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace WebApiDemo.Services
{
    public class KafkaService : IKafkaService
    {
        private readonly IProducer<Null, string> _producer;

        public KafkaService(IConfiguration configuration)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"]
            };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task ProduceAsync(string topic, string message)
        {
            await _producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
        }

        public void Dispose() => _producer.Dispose();
    }
}