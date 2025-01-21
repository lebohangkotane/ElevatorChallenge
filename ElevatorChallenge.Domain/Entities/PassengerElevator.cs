using ElevatorChallenge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Domain.Entities
{
    public class PassengerElevator : ElevatorBase
    {
        public PassengerElevator(int id)
            : base(id, maxCapacity: 10, speed: 1.0, type: ElevatorType.Passenger)
        {
        }
    }
}
