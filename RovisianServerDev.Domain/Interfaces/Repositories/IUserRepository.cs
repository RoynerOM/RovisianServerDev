using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<UsuarioEntity>
    {
        Task<UsuarioEntity?> GetLogin(string dni);
        Task<IEnumerable<UsuarioEntity>> GetByRol(Guid rolId);
        Task<IEnumerable<UsuarioEntity>> GetByName(string name);
    }
}
