using ElevatorChallenge.Domain.Entities;
using ElevatorChallenge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Infrastructure.Repositories
{
    public class ElevatorRepository : IElevatorRepository
    {
        private List<Elevator> _elevators;

        public ElevatorRepository(List<Elevator> elevators)
        {
            _elevators = elevators;
            // Initialize elevators
        }

        public Elevator GetElevator(int id)
        {
            return _elevators.FirstOrDefault(e => e.Id == id);
        }

        public void AddPassengers(int passengers)
        {
            throw new NotImplementedException();
        }

        public bool CanAddPassengers(int passengers)
        {
            throw new NotImplementedException();
        }

        public void MoveToFloor(int floor)
        {
            throw new NotImplementedException();
        }

        public void UpdateElevator(Elevator elevator)
        {
            // Update elevator status
        }
    }
}
