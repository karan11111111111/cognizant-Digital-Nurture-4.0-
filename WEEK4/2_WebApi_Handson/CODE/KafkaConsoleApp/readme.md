
# Kafka Console Application

## Features
- Dual-mode operation (Producer/Consumer/Both)
- Message serialization using JSON
- Real-time message display with timestamps
- Error handling for Kafka operations
- Configurable Kafka settings

## Prerequisites
- .NET 8 SDK
- Kafka server (localhost:9092 by default)

## Configuration
Edit `appsettings.json`:
```json
{
  "Kafka": {
    "BootstrapServers": "localhost:9092",
    "Topic": "console-chat",
    "ConsumerGroup": "console-group"
  }
}
```
## Usage Modes

| Option | Description             |
|--------|-------------------------|
| 1      | Producer-only mode      |
| 2      | Consumer-only mode      |
| 3      | Both producer and consumer |

```bash
# Start producer
dotnet run -- 1

# Start consumer in another terminal
dotnet run -- 2
```