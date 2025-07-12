namespace KafkaConsoleApp.Models
{
    public class ChatMessage
    {
        public string Sender { get; set; } = "ConsoleApp";
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public override string ToString()
        {
            return $"[{Timestamp:HH:mm:ss}] {Sender}: {Content}";
        }
    }
}