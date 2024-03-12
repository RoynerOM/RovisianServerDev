using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Services;

namespace RovisianServerDev.Domain.UseCases.Rol
{
    public interface IUpdateRolUseCase : IUseCase<DataState<bool>, RolEntity>
    {

    }

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
