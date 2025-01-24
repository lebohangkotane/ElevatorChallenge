using ElevatorChallenge.Domain.Entities;

namespace ElevatorChallenge.Application.Interfaces
{
    public interface IElevatorRepository
    {
        IEnumerable<ElevatorBase> GetAll();
        ElevatorBase GetById(int id);
        void Update(ElevatorBase elevator);
    }
}
