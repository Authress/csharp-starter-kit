using AuthressStarterKit;
using Microsoft.AspNetCore.Authentication.JwtBearer;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Automatically generate an OpenAPI specification for your application (Configured using: https://aka.ms/aspnetcore/swashbuckle)
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
            options.Authority = $"https://{AuthressConfiguration.CustomDomain}";
        });



        var app = builder.Build();

        app.UseCors("AllowedCorsOrigins");
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        // app.UseMiddleware<UserMiddleware>();

        app.Run();
    }
}