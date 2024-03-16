using RovisianServerDev.Domain.Resources;
using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Interfaces.Services
{
    public interface IStateService
    {
        Task<DataState<IEnumerable<EstadoEntity>>> GetAll();
        Task<DataState<EstadoEntity>> GetById(Guid id);
        Task<DataState<Task>> SaveState(EstadoEntity e);
        Task<DataState<bool>> UpdateState(EstadoEntity e);
        Task<DataState<bool>> DeleteState(Guid id);
    }
}
