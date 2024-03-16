using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<UsuarioEntity>
    {
        Task<UsuarioEntity?> GetLogin(string dni);
    }
}
