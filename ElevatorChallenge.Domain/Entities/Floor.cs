﻿namespace ElevatorChallenge.Domain.Entities
{
    public class Floor
    {
        public int FloorNumber { get; set; }
        public List<int> WaitingPassengers { get; set; }
        public Floor(int number)
        {
            FloorNumber = number;
            WaitingPassengers = new List<int>();
        }
        public void AddWaitingPassengers(int passengers)
        {
            WaitingPassengers.Add(passengers);
            Console.WriteLine($"{passengers} passengers are waiting on floor {FloorNumber}.");
        }
    }
}
