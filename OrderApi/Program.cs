using Microsoft.EntityFrameworkCore;
using OrderApi.Application.Common;
using OrderApi.Infrastructure.Data;
using OrderApi.Domain.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// Registering DB Context (PostgreSQL in this case)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registering application-specific services
builder.Services.AddApplicationServices(); // Custom services (like services from Application layer)

// Registering infrastructure services
builder.Services.AddInfrastructure(); // Infrastructure layer, if you have repositories or other infrastructure logic

// Registering controllers for API endpoints
builder.Services.AddControllers();

// Register Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Authentication (if needed)
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options => { /* Configure JWT bearer options */ });

var app = builder.Build();

// Configure middleware pipeline

// Use Swagger and Swagger UI only in Development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Enables Swagger generation
    app.UseSwaggerUI(); // Enables Swagger UI to view API documentation
}

// Enable HTTPS Redirection (forces HTTPS in production)
app.UseHttpsRedirection();

// Enable Authorization (if your API requires authentication)
app.UseAuthorization();

// Enable Routing
app.UseRouting();

// Map Controllers to handle API requests
app.MapControllers();

// Run the application
app.Run();