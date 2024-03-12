using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RovisianServerDev.Domain.UseCases.Rol
{
    public interface IDeleteRolUseCase : IUseCase<DataState<bool>, Guid>
    {

    }

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
