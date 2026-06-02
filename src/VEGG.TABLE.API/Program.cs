using System.Text.Json;

using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

using Scalar.AspNetCore;

using VEGG.TABLE.API.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// 1. Add native OpenAPI support
builder.Services.AddOpenApi();

// Add other services
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProduceRepository, ProduceRepository>();
builder.Services.AddScoped<IProduceService, ProduceService>();

// Get the connection string from appsettings.json
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Missing connection string 'DefaultConnection'.");

// Add a service to the build in the form of our database context, configured to use SQL Server.
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString));

// Health checks: one per critical table, each reports queryability + descriptive message.
builder.Services.AddHealthChecks()
    .AddCheck<UserTableHealthCheck>("users")
    .AddCheck<ProduceTableHealthCheck>("produce");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClient", policy =>
    {
        policy.WithOrigins("http://localhost:5209") // Update to your Client port
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// 2. Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // Dev-only: apply pending migrations on startup.
    using (var scope = app.Services.CreateScope())
    {
        scope.ServiceProvider.GetRequiredService<DBContext>().Database.Migrate();
    }

    // Register the OpenAPI endpoint
    app.MapOpenApi();
    // Register Scalar UI
    app.MapScalarApiReference();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseCors("AllowClient");
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = WriteHealthResponse
});
app.Run();

static Task WriteHealthResponse(HttpContext ctx, HealthReport report)
{
    ctx.Response.ContentType = "application/json";
    var payload = new
    {
        status = report.Status.ToString(),
        checks = report.Entries.Select(e => new
        {
            name = e.Key,
            status = e.Value.Status.ToString(),
            description = e.Value.Description,
            error = e.Value.Exception?.Message
        })
    };
    return ctx.Response.WriteAsync(JsonSerializer.Serialize(payload));
}