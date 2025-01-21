using ElevatorChallenge.Domain.Entities;

namespace ElevatorChallenge.Domain.Interfaces
{
    public interface IElevatorRepository
    {
        IEnumerable<ElevatorBase> GetAll();
        ElevatorBase GetById(int id);
        void Update(ElevatorBase elevator);
    }
}
