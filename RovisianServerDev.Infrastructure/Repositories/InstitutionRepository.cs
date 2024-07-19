using Microsoft.EntityFrameworkCore;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Repositories;
using RovisianServerDev.Infrastructure.Data;

namespace RovisianServerDev.Infrastructure.Repositories
{
    public class InstitutionRepository : BaseRepository<InstitucionEntity>, IInstitutionRepository
    {
        public InstitutionRepository(RovisianDBContext context) : base(context) { }

        public new async Task<IEnumerable<InstitucionEntity>> GetAll()
        {
            return await Task.FromResult(_entities.Include(x => x.Banco).Include(x => x.Contador).Where(x => x.Borrado == false).AsEnumerable());
        }

        public new async Task<InstitucionEntity> GetById(Guid id)
        {
            return await _entities.Include(x => x.Banco).Include(x => x.Contador).FirstAsync(x => x.Id == id && x.Borrado == false);
        }

        public async Task<InstitucionEntity?> GetByCode(int code)
        {
            return await _entities.Include(x => x.Banco).Include(x => x.Contador).FirstOrDefaultAsync(x => x.Codigo == code && x.Borrado == false);
        }

        public async Task<IEnumerable<InstitucionEntity>> GetByName(string name)
        {
            return await Task.FromResult(_entities.Include(x => x.Banco).Include(x => x.Contador).Where(p => p.Nombre.ToLower().Contains(name.ToLower())).AsEnumerable());
        }

        public async Task<IEnumerable<InstitucionEntity>> GetByUser(Guid userId)
        {
            return await Task.FromResult(_entities.Include(x => x.Banco).Include(x => x.Contador).Where(x => x.ContadorId==userId&& x.Borrado == false).AsEnumerable());
        }
    }
}
