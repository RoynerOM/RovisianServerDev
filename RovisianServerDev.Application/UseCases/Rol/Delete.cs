﻿using RovisianServerDev.Domain.Resources;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.Rol
{
    public interface IDeleteRolUseCase : IUseCase<DataState<bool>, Guid>{}

    public class DeleteRolCase : IDeleteRolUseCase
    {
        private readonly IRolService _rolService;
        public DeleteRolCase(IRolService rolService)
        {
            this._rolService = rolService;
        }

        public async Task<DataState<bool>> Call(Guid values) => await _rolService.Delete(values);

    }
}