using Confluent.Kafka;
using KafkaConsoleApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace KafkaConsoleApp.Consumers
{
    public class KafkaChatConsumer : BackgroundService
    {
        private readonly IConsumer<Null, string> _consumer;
        private readonly string _topic;

        public KafkaChatConsumer(IConfiguration configuration)
        {
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"] ?? "localhost:9092",
                GroupId = configuration["Kafka:ConsumerGroup"] ?? "console-group",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false
            };

            _topic = configuration["Kafka:Topic"] ?? "console-chat";
            _consumer = new ConsumerBuilder<Null, string>(consumerConfig).Build();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Subscribe(_topic);
            Console.WriteLine("Consumer started. Waiting for messages...");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = await Task.Run(() => _consumer.Consume(stoppingToken));
                    var chatMessage = JsonSerializer.Deserialize<ChatMessage>(consumeResult.Message.Value);
                    Console.WriteLine(chatMessage);
                    
                    _consumer.Commit(consumeResult);
                }
                catch (ConsumeException ex)
                {
                    Console.WriteLine($"Error consuming message: {ex.Error.Reason}");
                }
                catch (OperationCanceledException)
                {
                    // Expected when stopping
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }

        public override void Dispose()
        {
            _consumer.Close();
            _consumer.Dispose();
            base.Dispose();
        }
    }
}