using ElevatorChallenge.Domain.Entities;

namespace ElevatorChallenge.Domain.Interfaces
{
    public interface IElevatorDispatcher
    {
        Task<ElevatorBase> GetOptimalElevator(ElevatorRequest request);
        Task UpdateElevatorStatus(int elevatorId);
    }
}
