using ElevatorChallenge.Application.Interfaces;
using ElevatorChallenge.Application.Services;
using ElevatorChallenge.Domain.Interfaces;
using ElevatorChallenge.Infrastructure.Factories;
using ElevatorChallenge.Infrastructure.Repositories;
using ElevatorChallenge.Presentation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

class Program
{
    static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.Debug()
            .CreateLogger();

        try
        {
            var host = Host.CreateDefaultBuilder(args)
                .UseSerilog() // Use Serilog
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<ElevatorChallenge.Application.Interfaces.IElevatorRepository, InMemoryElevatorRepository>();
                    services.AddSingleton<IElevatorDispatcher, ElevatorDispatchService>();
                    services.AddSingleton<IElevatorFactory, ElevatorFactory>(); 
                    services.AddSingleton<ConsoleUI>();
                    services.AddSingleton(Log.Logger);
                    services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
                })
                .Build();

            var ui = host.Services.GetRequiredService<ConsoleUI>();
            await ui.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex.Message);
            throw;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}