using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Add native OpenAPI support
builder.Services.AddOpenApi();

// Add other services
builder.Services.AddControllers();

// Get the connection string from appsettings.json
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add a service to the build in the form of our database context, configured to use SQL Server.
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// 2. Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // Register the OpenAPI endpoint
    app.MapOpenApi();

    // Register Scalar UI
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
