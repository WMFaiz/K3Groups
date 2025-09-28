using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

// ✅ 1. type declarations (records) go before any top-level code

// ✅ 2. top-level code
var builder = WebApplication.CreateBuilder(args);

const string CorsPolicy = "FrontendDev";
builder.Services.AddCors(o => o.AddPolicy(CorsPolicy, p =>
    p.WithOrigins("http://localhost:5173", "http://127.0.0.1:5173")
     .AllowAnyHeader()
     .AllowAnyMethod()
     .AllowCredentials()
));

builder.Services.AddOpenApi();

var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

var users = JsonSerializer
    .Deserialize<UserList>(File.ReadAllText("users.json"), options)?
    .Data ?? new List<User>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors(CorsPolicy);

app.MapPost("/auth/login", (LoginDto dto) =>
{
    if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
        return Results.BadRequest("Email/Password required");

    var match = users.FirstOrDefault(u =>
        u.Email.Equals(dto.Email, StringComparison.OrdinalIgnoreCase) &&
        u.Password == dto.Password
    );

    if (match is null)
        return Results.Unauthorized();

    return Results.Ok(new { accessToken = "dev-token" });
});

app.Run();

record User(string Email, string Password);
record UserList(List<User> Data);
record LoginDto(string Email, string Password);
