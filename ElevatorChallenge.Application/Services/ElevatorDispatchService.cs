using ElevatorChallenge.Application.DTOs;
using ElevatorChallenge.Domain.Entities;
using ElevatorChallenge.Domain.Enums;
using ElevatorChallenge.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Application.Services
{
    public class ElevatorDispatchService : IElevatorDispatcher
    {
        private readonly IElevatorRepository _repository;
        private readonly ILogger<ElevatorDispatchService> _logger;

        public ElevatorDispatchService(IElevatorRepository repository, ILogger<ElevatorDispatchService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ElevatorBase> GetOptimalElevator(ElevatorRequest request)
        {
            var elevators = _repository.GetAll();

            var availableElevators = elevators
                .Where(e => e.State != ElevatorState.OutOfService
                           && e.CanAddPassengers(request.PassengerCount))
                .ToList();

            if (!availableElevators.Any())
            {
                _logger.LogWarning("No available elevators for request: {Request}", request);
                return null;
            }

            var optimalElevator = availableElevators
                .OrderBy(e =>
                {
                    var score = Math.Abs(e.CurrentFloor - request.RequestedFloor);

                    // Prefer elevators already moving in the right direction
                    if (request.RequestedFloor > e.CurrentFloor && e.Direction == ElevatorDirection.Up)
                        score -= 2;
                    if (request.RequestedFloor < e.CurrentFloor && e.Direction == ElevatorDirection.Down)
                        score -= 2;

                    // Prefer idle elevators over busy ones
                    if (e.State == ElevatorState.Stationary)
                        score -= 1;

                    // Adjust score based on elevator type preference
                    if (e.GetType().Name.Contains(request.PreferredType.ToString()))
                        score -= 3;

                    return score;
                })
                .First();

            optimalElevator.AddDestination(request.RequestedFloor);
            _repository.Update(optimalElevator);

            return optimalElevator;
        }

        public async Task UpdateElevatorStatus(int elevatorId)
        {
            var elevator = _repository.GetById(elevatorId);
            elevator.Move();
            _repository.Update(elevator);
            await Task.CompletedTask;
        }
    }
}
