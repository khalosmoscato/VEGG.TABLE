

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Add native OpenAPI support
builder.Services.AddOpenApi();

// Add other services
builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProduceRepository, ProduceRepository>();
builder.Services.AddScoped<IProduceService, ProduceService>();

// Get the connection string from appsettings.json
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Missing connection string 'DefaultConnection'.");

// Add a service to the build in the form of our database context, configured to use SQL Server.
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString));

var key = Encoding.UTF8.GetBytes("SorryForPartyRockingSorryForPartyRocking");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = "your-name",
        ValidateAudience = true,
        ValidAudience = "your-app-name",
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();