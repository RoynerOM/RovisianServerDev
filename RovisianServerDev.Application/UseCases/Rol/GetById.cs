using RovisianServerDev.Domain.Resources;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.Rol
{
    public interface IGetByIdRolUseCase : IUseCase<DataState<RolEntity>, Guid> {}

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
