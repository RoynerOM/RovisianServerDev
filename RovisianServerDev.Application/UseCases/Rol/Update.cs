using RovisianServerDev.Domain.Resources;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.Rol
{
    public interface IUpdateRolUseCase : IUseCase<DataState<bool>, RolEntity>{}

    public class UpdateRolCase : IUpdateRolUseCase
    {
        private readonly IRolService _rolService;
        public UpdateRolCase(IRolService rolService)
        {
            this._rolService = rolService;
        }

        public async Task<DataState<bool>> Call(RolEntity? values) => await _rolService.Update(values!);

    }
}
