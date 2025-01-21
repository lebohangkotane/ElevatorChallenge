using ElevatorChallenge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Domain.Entities
{
    public class FreightElevator : ElevatorBase
    {
        public FreightElevator(int id)
            : base(id, maxCapacity: 20, speed: 0.5, type: ElevatorType.Freight)
        {
        }
    }
}
