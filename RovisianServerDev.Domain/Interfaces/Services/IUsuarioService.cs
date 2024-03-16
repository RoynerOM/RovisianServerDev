using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioEntity>> GetAll();
        Task<UsuarioEntity> GetById(Guid id);
        Task Save(UsuarioEntity e);
        Task<bool> Update(UsuarioEntity e);
        Task<bool> Delete(Guid id);

        Task<UsuarioEntity> GetLogin(string dni);
    }
}
