using Microsoft.EntityFrameworkCore;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Repositories;
using RovisianServerDev.Infrastructure.Data;

namespace RovisianServerDev.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<UsuarioEntity>, IUserRepository
    {

        public UserRepository(RovisianDBContext context) : base(context) { }

        public async Task<UsuarioEntity?> GetLogin(string dni)
        {
            return await _entities.FirstOrDefaultAsync(user => user.Cedula == dni);
        }
    }
}
