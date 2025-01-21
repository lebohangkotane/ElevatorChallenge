using ElevatorChallenge.Domain.Enums;

namespace ElevatorChallenge.Domain.Entities
{
    public class GlassElevator : ElevatorBase
    {
        public GlassElevator(int id)
            : base(id, maxCapacity: 8, speed: 1.0, type: ElevatorType.Glass)
        {
        }
    }
}
