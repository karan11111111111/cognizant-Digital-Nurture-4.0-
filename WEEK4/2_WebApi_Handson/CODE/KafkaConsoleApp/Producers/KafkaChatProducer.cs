using Confluent.Kafka;
using KafkaConsoleApp.Models;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace KafkaConsoleApp.Producers
{
    public class KafkaChatProducer : IDisposable
    {
        private readonly IProducer<Null, string> _producer;
        private readonly string _topic;

        public KafkaChatProducer(IConfiguration configuration)
        {
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"] ?? "localhost:9092",
                Acks = Acks.All
            };

            _topic = configuration["Kafka:Topic"] ?? "console-chat";
            _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
        }

        public async Task ProduceAsync(string message)
        {
            var chatMessage = new ChatMessage { Content = message };
            var jsonMessage = JsonSerializer.Serialize(chatMessage);

            try
            {
                await _producer.ProduceAsync(_topic, new Message<Null, string> { Value = jsonMessage });
            }
            catch (ProduceException<Null, string> ex)
            {
                Console.WriteLine($"Failed to deliver message: {ex.Error.Reason}");
            }
        }

        public void Dispose()
        {
            _producer.Flush(TimeSpan.FromSeconds(5));
            _producer.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}