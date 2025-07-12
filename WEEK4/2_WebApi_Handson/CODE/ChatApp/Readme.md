# Windows Forms Chat Application with Kafka


## Features
- Real-time messaging using Apache Kafka
- Modern UI with enhanced Send button
- Multi-user support with unique usernames
- Message timestamps (`[HH:mm:ss]`)
- Auto-scrolling message history
- Responsive design with hover effects

## Prerequisites
- .NET 8 SDK
- Running Kafka server (localhost:9092)
- WebApiDemo running (for JWT tokens if secured)

## Configuration
Edit `appsettings.json`:
```json
{
  "Kafka": {
    "BootstrapServers": "localhost:9092",
    "Topic": "chat-messages",
    "ConsumerGroup": "chat-app-group"
  }
}
```
### How to Run
```bash
dotnet run
```
### Message Flow
![alt text](image.png)