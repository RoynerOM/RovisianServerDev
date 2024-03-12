using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Services
{
    public interface IBancoService
    {
        Task<DataState<IEnumerable<BancoEntity>>> GetAll();
        Task<DataState<BancoEntity>> GetById(Guid id);
        Task<DataState<Task>> Save(BancoEntity e);
        Task<DataState<bool>> Update(BancoEntity e);
        Task<DataState<bool>> Delete(Guid id);
    }
}
