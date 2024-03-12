﻿using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<EstadoEntity> EstateRepository { get; }
        IBaseRepository<RolEntity> RolRepository { get; }
        IBaseRepository<BancoEntity> BancoRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
