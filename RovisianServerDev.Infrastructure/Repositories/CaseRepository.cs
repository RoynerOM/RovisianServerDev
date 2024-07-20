using Microsoft.EntityFrameworkCore;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Repositories;
using RovisianServerDev.Infrastructure.Data;

namespace RovisianServerDev.Infrastructure.Repositories
{
    public class CaseRepository : BaseRepository<CasoEntity>, ICaseRepository
    {
        public CaseRepository(RovisianDBContext context) : base(context) { }

        public async Task<CasoEntity?> GetByConsecutive(string consecutive)
        {
            return await _entities.FirstOrDefaultAsync(x => x.CodigoCaso.ToLower() == consecutive.ToLower()); ;
        }

        public async Task<IEnumerable<CasoEntity>> GetByReception(Guid stateId)
        {
            return await Task.FromResult(Array.Empty<CasoEntity>());
        }

        public async Task<IEnumerable<CasoEntity>> GetByState(Guid stateId)
        {
            return await Task.FromResult(_entities.Where(x => x.EstadoId == stateId).AsEnumerable());
        }

        public async Task<IEnumerable<CasoEntity>> GetByUser(Guid userId)
        {
            return await Task.FromResult(_entities.Where(x => x.ContadorId == userId || x.TramitadorId == userId).AsEnumerable());
        }

        public async Task Reassign(CasoEntity e)
        {
            _entities.Update(e);
            await Task.CompletedTask;
        }
    }
}
