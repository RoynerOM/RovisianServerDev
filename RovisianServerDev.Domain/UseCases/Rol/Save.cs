using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Services;

namespace RovisianServerDev.Domain.UseCases.Rol
{
    public interface ISaveRolUseCase : IUseCase<DataState<Task>, RolEntity>
    {

    }

    public class SaveRolCase : ISaveRolUseCase
    {
        private readonly IRolService _rolService;
        public SaveRolCase(IRolService rolService)
        {
            this._rolService = rolService;
        }

        public async Task<DataState<Task>> Call(RolEntity? values) => await _rolService.Save(values!);

    }
}
