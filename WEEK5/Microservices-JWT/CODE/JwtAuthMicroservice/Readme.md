# JWT Authentication Microservice - ASP.NET Core Web API

## Overview
This project implements a secure microservice with JWT (JSON Web Token) authentication and role-based authorization in ASP.NET Core. It demonstrates all four key requirements from the assignment:

1. JWT token generation
2. Endpoint protection with `[Authorize]`
3. Role-based access control
4. Token expiry handling

## Features

- 🔒 Secure JWT authentication
- 👮 Role-based authorization (Admin/User)
- ⏳ Token expiration handling (60 minutes)
- 🛡️ Protected API endpoints
- 📝 Claims-based identity


## Implementation Details

### 1. JWT Configuration (`appsettings.json`)

```json
{
  "Jwt": {
    "Key": "ThisIsASecretKeyForJwtToken",
    "Issuer": "MyAuthServer",
    "Audience": "MyApiUsers",
    "DurationInMinutes": 60
  }
}
```

### 2. Authentication Setup (Program.cs)
```csharp
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };

        // Token expiry handling
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                if (context.Exception is SecurityTokenExpiredException)
                {
                    context.Response.Headers["Token-Expired"] = "true";
                }
                return Task.CompletedTask;
            }
        };
    });

```
### 3. Authentication Controller
```csharp
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        if (IsValidUser(model))
        {
            var token = GenerateJwtToken(model.Username);
            return Ok(new { Token = token });
        }
        return Unauthorized();
    }
    
    // Token generation logic...
}
```
### 4. Protected Endpoints
#### Regular protected endpoint:

```csharp
[Authorize]
[HttpGet("data")]
public IActionResult GetSecureData()
{
    return Ok("This is protected data.");
}
```
### Admin-only endpoint:

```csharp
[Authorize(Roles = "Admin")]
[HttpGet("dashboard")]
public IActionResult GetAdminDashboard()
{
    return Ok("Welcome to the admin dashboard.");
}
```
## Testing the API

### 1. Get JWT Token

#### Request:

```text
POST /api/auth/login
Content-Type: application/json

{
    "username": "admin",
    "password": "admin123"
}
```
#### Response:

```json
{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```
### 2. Access Protected Endpoints
#### Regular protected endpoint:

```text
GET /api/secure/data
Authorization: Bearer <your_token>
```
#### Admin-only endpoint:

```text
GET /api/admin/dashboard
Authorization: Bearer <your_token>
```
#### Error Handling

- `401 Unauthorized`: Invalid or missing token

- `403 Forbidden`: Valid token but missing required role

- `Token-Expired`: true header: When token is expired

### Setup Instructions
#### 1.   Clone the repository

#### 2.  Restore dependencies:

```bash
dotnet restore
```
#### 3. Run the application:



```bash
dotnet run
```
#### 4. Test endpoints using Postman or Swagger UI

## Expected Outputs

### 1. Successful Login (`POST /api/auth/login`)
**Request:**
```json
{
    "username": "admin",
    "password": "admin123"
}
```
**Response (200 OK):**

```json
{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```
### 2. Protected Endpoint (`GET /api/secure/data`)
**Request Headers:**

```text
Authorization: Bearer <valid_token>
```
**Response (200 OK):**

```json
{
    "message": "This is protected data.",
    "user": "admin",
    "claims": [
        {
            "type": "nameid",
            "value": "1"
        },
        {
            "type": "name",
            "value": "admin"
        }
    ]
}
```

### 3. Admin Endpoint (`GET /api/admin/dashboard`)
**Request Headers:**

```text
Authorization: Bearer <admin_token>
```

**Response (200 OK):**

```json
{
    "message": "Welcome to the admin dashboard.",
    "user": "admin",
    "isAdmin": true
}
```
### 4. Error Cases
**Invalid Token (401 Unauthorized)**
```text
GET /api/secure/data
Authorization: Bearer invalid_token
```
**Response:**

```http
HTTP/1.1 401 Unauthorized
```
**Expired Token (401 + Header)**
```http
HTTP/1.1 401 Unauthorized
Token-Expired: true
```

**Missing Role (403 Forbidden)**
```text
GET /api/admin/dashboard
Authorization: Bearer <non_admin_token>

```
**Response:**

```http
HTTP/1.1 403 Forbidden
```

---
## Dependencies
- ASP.NET Core 7.0

- Microsoft.AspNetCore.Authentication.JwtBearer

## Security Considerations

- Always use HTTPS in production

- Store JWT secret securely (not in code)

- Implement proper password hashing

- Consider adding rate limiting

---


