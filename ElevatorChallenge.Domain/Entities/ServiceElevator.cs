using ElevatorChallenge.Domain.Enums;

namespace ElevatorChallenge.Domain.Entities
{
    public class ServiceElevator : ElevatorBase
    {
        public ServiceElevator(int id)
            : base(id, maxCapacity: 12, speed: 0.8, type: ElevatorType.Service)
        {
        }
    }
}
