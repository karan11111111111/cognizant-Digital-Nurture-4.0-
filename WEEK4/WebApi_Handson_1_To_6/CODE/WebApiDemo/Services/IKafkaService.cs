namespace WebApiDemo.Services
{
    public interface IKafkaService
    {
        Task ProduceAsync(string topic, string message);
    }
}