using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;

namespace ChatApp.Services
{
    public class KafkaService : IKafkaService
    {
        private readonly IProducer<Null, string> _producer;
        private readonly IConsumer<Null, string> _consumer;
        private readonly string _topic;
        private CancellationTokenSource _cancellationTokenSource = new();

        public KafkaService(IConfiguration configuration)
        {
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"] ?? throw new ArgumentNullException("Kafka:BootstrapServers")
            };

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"] ?? throw new ArgumentNullException("Kafka:BootstrapServers"),
                GroupId = configuration["Kafka:ConsumerGroup"] ?? "default-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _topic = configuration["Kafka:Topic"] ?? "default-topic";
            _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
            _consumer = new ConsumerBuilder<Null, string>(consumerConfig).Build();
        }

        public void Produce(string message)
        {
            _producer.Produce(_topic, new Message<Null, string> { Value = message });
            _producer.Flush(TimeSpan.FromSeconds(1));
        }

        public void StartConsuming(Action<string> messageHandler)
        {
            _consumer.Subscribe(_topic);

            Task.Run(() =>
            {
                while (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    try
                    {
                        var consumeResult = _consumer.Consume(_cancellationTokenSource.Token);
                        messageHandler?.Invoke(consumeResult.Message.Value);
                    }
                    catch (OperationCanceledException)
                    {
                        // Expected when stopping
                    }
                }
            });
        }

        public void StopConsuming()
        {
            _cancellationTokenSource.Cancel();
            _consumer.Close();
        }

        public void Dispose()
        {
            _producer?.Dispose();
            _consumer?.Dispose();
            _cancellationTokenSource?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}