using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Interfaces.Services
{
    public interface ICaseService
    {
        Task<IEnumerable<CasoEntity>> GetAll();
        Task<IEnumerable<CasoEntity>> GetByUser(Guid userId);
        Task<IEnumerable<CasoEntity>> GetByState(Guid stateId);
        Task<IEnumerable<CasoEntity>> GetByReception(Guid stateId);
        Task<CasoEntity> GetById(Guid id);
        Task<CasoEntity> GetByConsecutive(string consecutive);
        Task Reassign(CasoEntity e);
        Task Save(CasoEntity e);
        Task<bool> Update(CasoEntity e);
        Task<bool> Delete(Guid id);
    }
}
