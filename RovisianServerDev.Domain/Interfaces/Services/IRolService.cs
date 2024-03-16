using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Interfaces.Services
{
    public interface IRolService
    {
        Task<IEnumerable<RolEntity>> GetAll();
        Task<RolEntity> GetById(Guid id);
        Task Save(RolEntity e);
        Task<bool> Update(RolEntity e);
        Task<bool> Delete(Guid id);
    }
}
