using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<EstadoEntity> EstateRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
