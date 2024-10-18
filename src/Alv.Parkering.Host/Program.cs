using Alv.Parkering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var AllowedOrigins = "_allowedOrigins";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructure();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: AllowedOrigins,
        policy =>
        {
            policy.WithOrigins("*", "*");
        }
    );
});

var app = builder.Build();

app.UseCors(AllowedOrigins);
app.MapControllers();

app.Run();
