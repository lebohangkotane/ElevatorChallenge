namespace ElevatorChallenge
{
    public class Elevator
    {
        public int ElevatorId { get; set; }
        public int CurrentFloor { get; set; }
        public int DestinationFloor { get; set; }
        public bool IsMoving { get; set; }
        public string Direction { get; set; }
        public int PassengerCount { get; set; }
        public int MaxCapacity { get; set; }

        public Elevator(int id, int maxCapacity)
        {
            ElevatorId = id;
            CurrentFloor = 0; // Assuming ground floor as the starting point
            IsMoving = false;
            Direction = "Stationary";
            PassengerCount = 0;
            MaxCapacity = maxCapacity;
        }

        public void MoveToFloor(int floor)
        {
            if (floor == CurrentFloor)
            {
                Console.WriteLine($"Elevator {ElevatorId} is already at floor {floor}.");
                return;
            }

            IsMoving = true;
            DestinationFloor = floor;
            Direction = floor > CurrentFloor ? "Up" : "Down";
            Console.WriteLine($"Elevator {ElevatorId} is moving {Direction} to floor {DestinationFloor}.");

            // Simulate movement
            while (CurrentFloor != DestinationFloor)
            {
                CurrentFloor += Direction == "Up" ? 1 : -1;
                Console.WriteLine($"Elevator {ElevatorId} is at floor {CurrentFloor}.");
            }

            IsMoving = false;
            Direction = "Stationary";
            Console.WriteLine($"Elevator {ElevatorId} has arrived at floor {CurrentFloor}.");
        }

        public bool CanAddPassengers(int passengers)
        {
            return PassengerCount + passengers <= MaxCapacity;
        }

        public void AddPassengers(int passengers)
        {
            if (CanAddPassengers(passengers))
            {
                PassengerCount += passengers;
                Console.WriteLine($"Elevator {ElevatorId} added {passengers} passengers. Total passengers: {PassengerCount}.");
            }
            else
            {
                Console.WriteLine($"Elevator {ElevatorId} cannot add {passengers} passengers. Exceeds capacity.");
            }
        }
    }

}
