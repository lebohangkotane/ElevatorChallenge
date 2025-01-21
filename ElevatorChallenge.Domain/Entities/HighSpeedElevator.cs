using ElevatorChallenge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Domain.Entities
{
    public class HighSpeedElevator : ElevatorBase
    {
        public HighSpeedElevator(int id)
            : base(id, maxCapacity: 15, speed: 2.0, type: ElevatorType.HighSpeed)
        {
        }
    }
}
