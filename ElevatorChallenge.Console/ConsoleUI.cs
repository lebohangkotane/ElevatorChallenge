using ElevatorChallenge.Application.DTOs;
using ElevatorChallenge.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Console
{
    public class ConsoleUI
    {
        private readonly IElevatorDispatcher _dispatcher;
        private readonly IElevatorRepository _repository;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly ILogger<ConsoleUI> _logger;

        public ConsoleUI(
            IElevatorDispatcher dispatcher,
            IElevatorRepository repository,
            ILogger<ConsoleUI> logger)
        {
            _dispatcher = dispatcher;
            _repository = repository;
            _logger = logger;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public async Task Run()
        {
            // Start elevator movement simulation in background
            _ = SimulateElevatorMovement(_cancellationTokenSource.Token);

            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                await DisplayElevatorStatus();
                await HandleUserInput();
                await Task.Delay(100);
            }
        }

        private async Task SimulateElevatorMovement(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var elevators = _repository.GetAll();
                foreach (var elevator in elevators)
                {
                    await _dispatcher.UpdateElevatorStatus(elevator.Id);
                }
                await Task.Delay(1000, cancellationToken);
            }
        }

        private async Task DisplayElevatorStatus()
        {
            Console.Clear();
            Console.WriteLine("=== Elevator System Status ===");

            var elevators = _repository.GetAll();
            foreach (var elevator in elevators)
            {
                Console.WriteLine($"Elevator {elevator.Id} ({elevator.GetType().Name}):");
                Console.WriteLine($"Floor: {elevator.CurrentFloor}");
                Console.WriteLine($"Direction: {elevator.Direction}");
                Console.WriteLine($"State: {elevator.State}");
                Console.WriteLine($"Passengers: {elevator.CurrentPassengers}/{elevator.MaxCapacity}");
                if (elevator.DestinationFloors.Any())
                    Console.WriteLine($"Destinations: {string.Join(", ", elevator.DestinationFloors)}");
                Console.WriteLine();
            }
        }

        private async Task HandleUserInput()
        {
            Console.WriteLine("Commands: [C]all Elevator, [Q]uit");
            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.C:
                    await HandleElevatorCall();
                    break;
                case ConsoleKey.Q:
                    _cancellationTokenSource.Cancel();
                    break;
            }
        }

        private async Task HandleElevatorCall()
        {
            try
            {
                Console.Write("\nEnter floor number: ");
                if (!int.TryParse(Console.ReadLine(), out int floor))
                {
                    Console.WriteLine("Invalid floor number");
                    return;
                }

                Console.Write("Enter number of passengers: ");
                if (!int.TryParse(Console.ReadLine(), out int passengers))
                {
                    Console.WriteLine("Invalid passenger count");
                    return;
                }

                Console.Write("Elevator type ([P]assenger, [F]reight, [H]igh-speed): ");
                var typeKey = Console.ReadKey();
                var preferredType = typeKey.Key switch
                {
                    ConsoleKey.F => ElevatorType.Freight,
                    ConsoleKey.H => ElevatorType.HighSpeed,
                    _ => ElevatorType.Passenger
                };

                var request = new ElevatorRequest(floor, passengers, preferredType);
                var elevator = await _dispatcher.GetOptimalElevator(request);

                if (elevator != null)
                {
                    Console.WriteLine($"\nElevator {elevator.Id} ({elevator.GetType().Name}) is being dispatched to floor {floor}");
                }
                else
                {
                    Console.WriteLine("\nNo available elevators at the moment");
                }

                await Task.Delay(2000);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error handling elevator call");
                Console.WriteLine("\nError processing request. Please try again.");
                await Task.Delay(2000);
            }
        }
    }
}
