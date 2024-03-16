using RovisianServerDev.Domain.Resources;
using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Interfaces.Services
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
