using ElevatorChallenge.Application.DTOs;
using ElevatorChallenge.Domain.Entities;

namespace ElevatorChallenge.Application.Interfaces
{
    public interface IElevatorDispatcher
    {
        Task<ElevatorBase> GetOptimalElevator(ElevatorRequest request);
        Task UpdateElevatorStatus(int elevatorId);
    }
}
