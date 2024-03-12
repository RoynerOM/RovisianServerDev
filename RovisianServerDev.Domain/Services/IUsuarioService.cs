using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Services
{
    public interface IUsuarioService
    {
        Task<DataState<IEnumerable<UsuarioEntity>>> GetAll();
        Task<DataState<UsuarioEntity>> GetById(Guid id);
        Task<DataState<Task>> Save(UsuarioEntity e);
        Task<DataState<bool>> Update(UsuarioEntity e);
        Task<DataState<bool>> Delete(Guid id);
    }
}
