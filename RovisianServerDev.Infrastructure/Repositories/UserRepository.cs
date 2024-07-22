using Microsoft.EntityFrameworkCore;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Repositories;
using RovisianServerDev.Infrastructure.Data;
using System.Net;

namespace RovisianServerDev.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<UsuarioEntity>, IUserRepository
    {

        public UserRepository(RovisianDBContext context) : base(context) { }

        public async Task<UsuarioEntity?> GetLogin(string dni)
        {
            return await _entities.FirstOrDefaultAsync(user => user.Cedula == dni);
        }

        public async Task<IEnumerable<UsuarioEntity>> GetByRol(Guid rolId)
        {
            return await Task.FromResult(_entities.Where(user => user.RolId == rolId).AsEnumerable());
        }
    }
}
