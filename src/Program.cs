using System.Text.RegularExpressions;

using AuthressStarterKit;
using Microsoft.AspNetCore.Authentication.JwtBearer;

internal class Program
{
    private static void Main(string[] args)
    {
        AuthressConfiguration.VerifyConfiguration();

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: "AllowedCorsOrigins",
                builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
        });
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.Authority = $"https://{Regex.Replace(AuthressConfiguration.AuthenticationCustomDomain, "https?://", "")}";
        });

        var app = builder.Build();

        app.UseCors("AllowedCorsOrigins");
        app.UseAuthentication();
        app.UseAuthorization();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
        }

        app.MapControllers();

        app.Run();
    }
}