# Web API with Kafka Integration

## Features
- REST API for Kafka message production
- JWT Authentication (Bearer tokens)
- Swagger documentation
- CRUD operations for Employee data
- Custom exception handling

## Prerequisites
- .NET 8 SDK
- Kafka server (localhost:9092)
- Postman/Swagger for testing

## Configuration
```json
// appsettings.json
{
  "Kafka": {
    "BootstrapServers": "localhost:9092",
    "Topic": "webapi-demo"
  },
  "Jwt": {
    "Key": "your-secret-key",
    "Issuer": "your-issuer",
    "Audience": "your-audience"
  }
}
```
## API Endpoints

| Endpoint           | Method | Description              |
|--------------------|--------|--------------------------|
| `/api/kafka/send`  | POST   | Send message to Kafka    |
| `/api/employee`    | GET    | List all employees       |
| `/api/auth/token`  | GET    | Generate JWT token       |

### Running the API
```bash
dotnet run
```
#### Access Swagger UI at: `https://localhost:5001/swagger`

### Architecture
![alt text](image.png)
