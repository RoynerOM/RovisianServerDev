using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Interfaces.Services
{
    public interface IStateService
    {
        Task<IEnumerable<EstadoEntity>> GetAll();
        Task<EstadoEntity> GetById(Guid id);
        Task Save(EstadoEntity e);
        Task<bool> Update(EstadoEntity e);
        Task<bool> Delete(Guid id);
    }
}
