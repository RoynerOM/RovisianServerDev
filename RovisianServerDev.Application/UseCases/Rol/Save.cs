using RovisianServerDev.Domain.Resources;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.Rol
{
    public interface ISaveRolUseCase : IUseCase<DataState<Task>, RolEntity>{}

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
