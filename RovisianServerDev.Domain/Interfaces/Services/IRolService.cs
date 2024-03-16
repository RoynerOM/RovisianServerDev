using RovisianServerDev.Domain.Resources;
using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Interfaces.Services
{
    public interface IRolService
    {
        Task<DataState<IEnumerable<RolEntity>>> GetAll();
        Task<DataState<RolEntity>> GetById(Guid id);
        Task<DataState<Task>> Save(RolEntity e);
        Task<DataState<bool>> Update(RolEntity e);
        Task<DataState<bool>> Delete(Guid id);
    }
}
