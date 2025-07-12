# Real-Time Chat System with Kafka and WebAPI

## Table of Contents
1. [Prerequisites](#prerequisites)
2. [Setup Instructions](#setup-instructions)
3. [Assignment Implementation](#assignment-implementation)
4. [Running the System](#running-the-system)
5. [Testing](#testing)
6. [Troubleshooting](#troubleshooting)

---

## Prerequisites
- .NET 8 SDK
- Docker Desktop (for Kafka)
- Postman/Swagger
- Visual Studio 2022 or VS Code

---

## Setup Instructions

### 1. Kafka Setup with Docker
```bash
# Create docker-compose.yml
version: '3'
services:
  zookeeper:
    image: confluentinc/cp-zookeeper:7.3.0
    environment:
      ZOOKEEPER_CLIENT_PORT: 2181

  kafka:
    image: confluentinc/cp-kafka:7.3.0
    depends_on:
      - zookeeper
    ports:
      - "9092:9092"
    environment:
      KAFKA_BROKER_ID: 1
      KAFKA_ZOOKEEPER_CONNECT: zookeeper:2181
      KAFKA_ADVERTISED_LISTENERS: PLAINTEXT://localhost:9092

# Start services
docker-compose up -d
```

### Assignment Implementation
## Assignment 1: WebAPI Foundation
```bash
dotnet new webapi -n WebApiDemo
cd WebApiDemo
```
### Key Files:

- `Controllers/ValuesController.cs` (Default template)

- `Program.cs` (Configure services)

## Assignment 2: Swagger & Postman
```bash
dotnet add package Swashbuckle.AspNetCore
```
### Configuration:

```csharp
// Program.cs
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new() { Title = "WebApiDemo", Version = "v1" });
});

app.UseSwagger();
app.UseSwaggerUI();
```
## Assignment 3: Employee CRUD API
```csharp
// Models/Employee.cs
public class Employee {
    public int Id { get; set; }
    public string Name { get; set; }
    // Add other properties
}

// Controllers/EmployeeController.cs
[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase {
    // Implement CRUD operations
}
```
## Assignment 4: Kafka Integration
```bash
dotnet add package Confluent.Kafka
```
### Kafka Service:

```csharp
// Services/KafkaService.cs
public class KafkaService {
    private readonly IProducer<Null, string> _producer;
    
    public KafkaService(IConfiguration config) {
        var producerConfig = new ProducerConfig {
            BootstrapServers = config["Kafka:BootstrapServers"]
        };
        _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
    }
    
    public async Task ProduceAsync(string message) {
        await _producer.ProduceAsync("chat-topic", 
            new Message<Null, string> { Value = message });
    }
}
```
## Assignment 5: JWT Authentication
```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
```
### Configuration:

```csharp
// Program.cs
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
```
## Assignment 6: Windows Forms ChatApp
```bash
dotnet new winforms -n ChatApp
cd ChatApp
dotnet add package Confluent.Kafka
```
### Core Logic:

```csharp
// ChatForm.cs
private readonly IKafkaService _kafkaService;

public ChatForm(IKafkaService kafkaService) {
    _kafkaService = kafkaService;
    _kafkaService.StartConsuming(DisplayMessage);
}

private void btnSend_Click(object sender, EventArgs e) {
    _kafkaService.Produce(txtMessage.Text);
}
```
### Running the System
1. Start Kafka:

```bash
docker-compose up -d
```
2. Run WebAPI:

```bash
cd WebApiDemo
dotnet run
```

3. Run ChatApp:

```bash
cd ChatApp
dotnet run
```
4. Run Console Consumer:

``` bash
cd KafkaConsoleApp
dotnet run
```
## Testing
## WebAPI Endpoints

| Endpoint          | Method | Description             |
|-------------------|--------|-------------------------|
| `/api/employee`   | GET    | Get all employees       |
| `/api/kafka/send` | POST   | Send message to Kafka   |
| `/auth/token`     | GET    | Generate JWT token      |

### ChatApp Features
1. Open multiple instances to simulate users

2. Verify real-time message sync

3. Check console consumer output

## Troubleshooting
### Common Issues:

1. Kafka connection failed:

    - Verify Docker containers are running

    - Check localhost:9092 accessibility

2. JWT validation errors:

    - Ensure consistent issuer/audience in config

    - Validate token expiration

3. Cross-thread UI updates:

    - Use Control.Invoke for WinForms updates

```csharp
// Proper thread handling example
if (txtChat.InvokeRequired) {
    txtChat.Invoke(() => txtChat.AppendText(message));
}
```
This guide covers implementation from basic WebAPI setup to full Kafka integration with authentication.
--- 