using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Repositories;
using RovisianServerDev.Infrastructure.Data;


namespace RovisianServerDev.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RovisianDBContext _context;
        private readonly IBaseRepository<EstadoEntity>? _estateRepository = null;
        private readonly IBaseRepository<RolEntity>? _rolRepository = null;

        public UnitOfWork(RovisianDBContext context)
        {
            this._context = context;
        }

        public IBaseRepository<EstadoEntity> EstateRepository => _estateRepository ?? new BaseRepository<EstadoEntity>(_context);
        public IBaseRepository<RolEntity> RolRepository => _rolRepository ?? new BaseRepository<RolEntity>(_context);

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void SaveChanges() => _context.SaveChanges();

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
