namespace ElevatorChallenge.Application.DTOs
{
    public record ElevatorRequest(
        int RequestedFloor,
        int PassengerCount,
        ElevatorType PreferredType = ElevatorType.Passenger
    );
}
