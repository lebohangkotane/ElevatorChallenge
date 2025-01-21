using ElevatorChallenge.Domain.Entities;
using ElevatorChallenge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Domain.Interfaces
{
    public interface IElevatorFactory
    {
        ElevatorBase CreateElevator(ElevatorType type, int id);
    }
}
