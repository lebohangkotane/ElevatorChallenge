using ElevatorChallenge.Domain.Enums;
using ElevatorChallenge.Domain.Exceptions;

namespace ElevatorChallenge.Domain.Entities
{
    public abstract class ElevatorBase
    {
        public int Id { get; protected set; }
        public int CurrentFloor { get; protected set; }
        public ElevatorDirection Direction { get; protected set; }
        public ElevatorState State { get; protected set; }
        public int CurrentPassengers { get; protected set; }
        public int MaxCapacity { get; protected set; }
        public double Speed { get; protected set; }
        public List<int> DestinationFloors { get; protected set; }
        public ElevatorType Type { get; protected set; }


        protected ElevatorBase(int id, int maxCapacity, double speed, ElevatorType type)
        {
            Id = id;
            MaxCapacity = maxCapacity;
            Speed = speed;
            Type = type;
            CurrentFloor = 1;
            Direction = ElevatorDirection.Idle;
            State = ElevatorState.Stationary;
            CurrentPassengers = 0;
            DestinationFloors = new List<int>();
        }

        public virtual bool CanAddPassengers(int count)
            => CurrentPassengers + count <= MaxCapacity;

        public virtual void AddPassengers(int count)
        {
            if (!CanAddPassengers(count))
                throw new DomainException("Elevator capacity exceeded");

            CurrentPassengers += count;
        }

        public virtual void AddDestination(int floor)
        {
            if (!DestinationFloors.Contains(floor))
                DestinationFloors.Add(floor);

            UpdateDirection();
        }

        protected virtual void UpdateDirection()
        {
            if (!DestinationFloors.Any())
            {
                Direction = ElevatorDirection.Idle;
                return;
            }

            var nextDestination = DestinationFloors.First();
            Direction = nextDestination > CurrentFloor ? ElevatorDirection.Up : ElevatorDirection.Down;
        }

        public virtual void Move()
        {
            if (!DestinationFloors.Any())
                return;

            State = ElevatorState.Moving;
            var nextFloor = DestinationFloors.First();

            if (CurrentFloor == nextFloor)
            {
                DestinationFloors.RemoveAt(0);
                State = ElevatorState.Stationary;
                UpdateDirection();
                return;
            }

            CurrentFloor += Direction == ElevatorDirection.Up ? 1 : -1;
        }
    }
}
