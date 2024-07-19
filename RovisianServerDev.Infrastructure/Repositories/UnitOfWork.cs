﻿using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Repositories;
using RovisianServerDev.Infrastructure.Data;

namespace RovisianServerDev.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RovisianDBContext _context;
        private readonly IBaseRepository<EstadoEntity>? _estateRepository = null;
        private readonly IBaseRepository<RolEntity>? _rolRepository = null;
        private readonly IBaseRepository<BancoEntity>? _bancoRepository = null;
        private readonly IUserRepository? _usuarioRepository = null;
        private readonly IInstitutionRepository? _institutionRepository = null;
        private readonly ICaseRepository? _caseRepository = null;   

        public UnitOfWork(RovisianDBContext context)
        {
            this._context = context;
        }

        public IBaseRepository<EstadoEntity> EstateRepository => _estateRepository ?? new BaseRepository<EstadoEntity>(_context);
        public IBaseRepository<RolEntity> RolRepository => _rolRepository ?? new BaseRepository<RolEntity>(_context);
        public IBaseRepository<BancoEntity> BancoRepository => _bancoRepository?? new BaseRepository<BancoEntity>(_context);
        public IUserRepository UsuarioRepository => _usuarioRepository ?? new UserRepository(_context);
        public IInstitutionRepository InstitutionRepository => _institutionRepository ?? new InstitutionRepository(_context);
        public ICaseRepository CaseRepository => _caseRepository ?? new CaseRepository(_context);

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void SaveChanges() => _context.SaveChanges();

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
