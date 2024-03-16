using RovisianServerDev.Domain.Resources;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.Rol
{
    public interface IGetAllRolUseCase : IUseCase<DataState<IEnumerable<RolEntity>>, object>{}

    public class GetAllRolCase : IGetAllRolUseCase
    {
        private readonly IRolService _rolService;
        public GetAllRolCase(IRolService rolService)
        {
            this._rolService = rolService;
        }

        public async Task<DataState<IEnumerable<RolEntity>>> Call(object? values) => await _rolService.GetAll();

    }
}
