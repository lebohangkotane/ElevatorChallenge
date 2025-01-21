using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge
{
    public class CentralControlSystem
    {
        public List<Elevator> Elevators { get; set; }
        public List<Floor> Floors { get; set; }

        public CentralControlSystem(int numberOfElevators, int numberOfFloors, int elevatorCapacity)
        {
            Elevators = new List<Elevator>();
            Floors = new List<Floor>();

            for (int i = 0; i < numberOfElevators; i++)
            {
                Elevators.Add(new Elevator(i + 1, elevatorCapacity));
            }

            for (int i = 0; i < numberOfFloors; i++)
            {
                Floors.Add(new Floor(i));
            }
        }

        public void CallElevator(int floorNumber, int passengers)
        {
            var floor = Floors.Find(f => f.FloorNumber == floorNumber);
            if (floor == null)
            {
                Console.WriteLine("Invalid floor number.");
                return;
            }

            floor.AddWaitingPassengers(passengers);

            // Find the nearest available elevator
            Elevator nearestElevator = null;
            int minDistance = int.MaxValue;

            foreach (var elevator in Elevators)
            {
                if (!elevator.IsMoving && elevator.CanAddPassengers(passengers))
                {
                    int distance = Math.Abs(elevator.CurrentFloor - floorNumber);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestElevator = elevator;
                    }
                }
            }

            if (nearestElevator != null)
            {
                nearestElevator.AddPassengers(passengers);
                nearestElevator.MoveToFloor(floorNumber);
            }
            else
            {
                Console.WriteLine("No available elevator can accommodate the passengers.");
            }
        }

        public void DisplayStatus()
        {
            foreach (var elevator in Elevators)
            {
                Console.WriteLine($"Elevator {elevator.ElevatorId}: Floor {elevator.CurrentFloor}, Direction {elevator.Direction}, Moving {elevator.IsMoving}, Passengers {elevator.PassengerCount}/{elevator.MaxCapacity}");
            }
        }
    }

}
