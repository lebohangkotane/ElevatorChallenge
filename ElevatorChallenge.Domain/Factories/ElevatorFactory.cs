using ElevatorChallenge.Domain.Entities;
using ElevatorChallenge.Domain.Enums;
using ElevatorChallenge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Domain.Factories
{
    public class ElevatorFactory : IElevatorFactory
    {
        public ElevatorBase CreateElevator(ElevatorType type, int id)
        {
            return type switch
            {
                ElevatorType.Passenger => new PassengerElevator(id),
                ElevatorType.Freight => new FreightElevator(id),
                ElevatorType.HighSpeed => new HighSpeedElevator(id),
                ElevatorType.Glass => new GlassElevator(id),
                ElevatorType.Service => new ServiceElevator(id),
                _ => throw new ArgumentException($"Unsupported elevator type: {type}")
            };
        }
    }
}
