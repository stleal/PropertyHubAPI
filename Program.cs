using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using PropertyHubAPI.Models;

namespace PropertyHubAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "PropertyHubAPI",
                Version = "v1",
                Description = "Property listing and inquiry management API"
            });
        });

        // CORS policy (kept from your original)
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                policy =>
                {
                    policy.WithOrigins("https://localhost:7258")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
        });

        // Database context
        builder.Services.AddDbContext<PropertyHubContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        // Middleware pipeline (correct order)
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors("AllowSpecificOrigin");
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "PropertyHubAPI V1");
        });

        app.MapControllers();

        app.Run();
    }
}