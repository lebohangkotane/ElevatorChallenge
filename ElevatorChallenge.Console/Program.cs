using ElevatorChallenge.Application.Services;
using ElevatorChallenge.Console;
using ElevatorChallenge.Domain.Interfaces;
using ElevatorChallenge.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

class Program
{
    private static void Main(string[] args)
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IElevatorRepository, InMemoryElevatorRepository>();
                    services.AddSingleton<IElevatorDispatcher, ElevatorDispatchService>();
                    services.AddSingleton<ConsoleUI>();

                    services.AddLogging(builder =>
                    {
                        builder.AddConsole();
                        builder.AddDebug();
                    });
                })
                .Build();

            var ui = host.Services.GetRequiredService<ConsoleUI>();
            await ui.Run();
        }
    }
}