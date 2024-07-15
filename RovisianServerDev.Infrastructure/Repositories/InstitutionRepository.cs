using Microsoft.EntityFrameworkCore;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Error;
using RovisianServerDev.Domain.Interfaces.Repositories;
using RovisianServerDev.Infrastructure.Data;

namespace RovisianServerDev.Infrastructure.Repositories
{
    public class InstitutionRepository : BaseRepository<InstitucionEntity>, IInstitutionRepository
    {
        public InstitutionRepository(RovisianDBContext context) : base(context) { }

        public async Task<InstitucionEntity?> GetByCode(int code)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Codigo==code&& x.Borrado == false);
        }

        public async Task<IEnumerable<InstitucionEntity>> GetByName(string name)
        {
            return await Task.FromResult(_entities.Where(p => p.Nombre.ToLower().Contains(name.ToLower())).AsEnumerable());
        }
    }
}
