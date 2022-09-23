using Dictionary_Blazor.Api.Services;
using Dictionary_Blazor.Api.Services.Contracts;
using Microsoft.Net.Http.Headers;

namespace Dictionary_Blazor;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddScoped<WordContract, WordService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseCors(policy => 
            policy.WithOrigins("https://localhost:7076", "http://localhost:5076")
                .AllowAnyMethod()
                .WithHeaders(HeaderNames.ContentType)
        );

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}