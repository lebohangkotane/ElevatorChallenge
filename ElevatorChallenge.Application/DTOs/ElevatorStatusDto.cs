using ElevatorChallenge.Domain.Enums;

namespace ElevatorChallenge.Application.DTOs
{
    public record ElevatorStatusDto(
        int Id,
        int CurrentFloor,
        ElevatorDirection Direction,
        ElevatorState State,
        int CurrentPassengers,
        int MaxCapacity,
        string Type
    );
}
