using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Services;

namespace RovisianServerDev.Domain.UseCases.Rol
{
    public interface IGetAllRolUseCase : IUseCase<DataState<IEnumerable<RolEntity>>, object>
    {

    }

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
