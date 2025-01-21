using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Application.DTOs
{
    public record ElevatorStatusDto(
        int Id,
        int CurrentFloor,
        ElevatorDirection Direction,
        ElevatorState State,
        int CurrentPassengers,
        int MaxCapacity,
        string Type
    );
}
