using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Services;

namespace RovisianServerDev.Domain.UseCases.Rol
{
    public interface IGetByIdRolUseCase : IUseCase<DataState<RolEntity>, Guid>
    {

    }

    public class GetByIdRolCase : IGetByIdRolUseCase
    {
        private readonly IRolService _rolService;
        public GetByIdRolCase(IRolService rolService)
        {
            this._rolService = rolService;
        }

        public async Task<DataState<RolEntity>> Call(Guid values) => await _rolService.GetById(values);

    }
}
