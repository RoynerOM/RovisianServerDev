using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Interfaces.Services
{
    public interface IBancoService
    {
        Task<IEnumerable<BancoEntity>> GetAll();
        Task<BancoEntity> GetById(Guid id);
        Task Save(BancoEntity e);
        Task<bool> Update(BancoEntity e);
        Task<bool> Delete(Guid id);
    }
}
