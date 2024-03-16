using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<EstadoEntity> EstateRepository { get; }
        IBaseRepository<RolEntity> RolRepository { get; }
        IBaseRepository<BancoEntity> BancoRepository { get; }
        IUserRepository UsuarioRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
