using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Interfaces.Repositories
{
    public interface ICaseRepository : IBaseRepository<CasoEntity>
    {
        Task<IEnumerable<CasoEntity>> GetByUser(Guid userId);
        Task<IEnumerable<CasoEntity>> GetByState(Guid stateId);
        Task<IEnumerable<CasoEntity>> GetByReception(Guid stateId);
        Task<CasoEntity?> GetByConsecutive(string consecutive);
        Task Reassign(CasoEntity e);
    }
}
