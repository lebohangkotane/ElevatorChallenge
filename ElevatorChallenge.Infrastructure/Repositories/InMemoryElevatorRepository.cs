using ElevatorChallenge.Domain.Entities;
using ElevatorChallenge.Domain.Enums;
using ElevatorChallenge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Infrastructure.Repositories
{
    public class InMemoryElevatorRepository : IElevatorRepository
    {
        private readonly Dictionary<int, ElevatorBase> _elevators = new();
        private readonly IElevatorFactory _elevatorFactory;

        public InMemoryElevatorRepository(IElevatorFactory elevatorFactory)
        {
            _elevatorFactory = elevatorFactory;
            InitializeElevators();
        }

        private void InitializeElevators()
        {
            _elevators.Add(1, _elevatorFactory.CreateElevator(ElevatorType.Passenger, 1));
            _elevators.Add(2, _elevatorFactory.CreateElevator(ElevatorType.Passenger, 2));
            _elevators.Add(3, _elevatorFactory.CreateElevator(ElevatorType.HighSpeed, 3));
            _elevators.Add(4, _elevatorFactory.CreateElevator(ElevatorType.Freight, 4));
            _elevators.Add(5, _elevatorFactory.CreateElevator(ElevatorType.Glass, 5));
        }

        public IEnumerable<ElevatorBase> GetAll() => _elevators.Values;
        public ElevatorBase GetById(int id) => _elevators[id];
        public void Update(ElevatorBase elevator) => _elevators[elevator.Id] = elevator;
    }
}
