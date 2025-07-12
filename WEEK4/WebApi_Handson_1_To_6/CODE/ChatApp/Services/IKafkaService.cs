using System;

namespace ChatApp.Services
{
    public interface IKafkaService : IDisposable
    {
        void Produce(string message);
        void StartConsuming(Action<string> messageHandler);
        void StopConsuming();
    }
}