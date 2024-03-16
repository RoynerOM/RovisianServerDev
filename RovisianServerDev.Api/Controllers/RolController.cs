using Microsoft.AspNetCore.Mvc;
using RovisianServerDev.Application.UseCases.Rol;
using RovisianServerDev.Application.DTOs;

namespace RovisianServerDev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IGetAllRolUseCase _getAllRolUseCase;
        private readonly IGetByIdRolUseCase _getByIdRolUseCase;
        private readonly IDeleteRolUseCase _deleteRolUseCase;
        private readonly IUpdateRolUseCase _updateRolUseCase;
        private readonly ISaveRolUseCase _saveRolUseCase;
        public RolController(IGetAllRolUseCase getAllRolUseCase, IGetByIdRolUseCase getByIdRolUseCase, IDeleteRolUseCase deleteRolUseCase, IUpdateRolUseCase updateRolUseCase, ISaveRolUseCase saveRolUseCase)
        {
            this._getAllRolUseCase = getAllRolUseCase;
            this._getByIdRolUseCase = getByIdRolUseCase;
            this._deleteRolUseCase = deleteRolUseCase;
            this._updateRolUseCase = updateRolUseCase;
            this._saveRolUseCase = saveRolUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()=> Ok(await _getAllRolUseCase.Call(null));

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id) => Ok(await _getByIdRolUseCase.Call(id));

        [HttpPost]
        public async Task<ActionResult> PostRol(RolDTO dto) => Ok(await _saveRolUseCase.Call(dto));

        [HttpPut]
        public async Task<ActionResult> PutRol(RolDTO dto) => Ok(await _updateRolUseCase.Call(dto));

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRol(Guid id) => Ok(await _deleteRolUseCase.Call(id));
    }
}
