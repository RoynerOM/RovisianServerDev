using Microsoft.AspNetCore.Mvc;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Application.UseCases.User;

/// Aplciar refactor para los nombres de la clase de casos de usos
namespace RovisianServerDev.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGetAllUsersUseCase _getAll;
        private readonly IGetUserByIdUseCase _getById;
        private readonly IDeleteUserUseCase _delete;
        private readonly IUpdateUserUseCase _update;
        private readonly ISaveUserUseCase _save;
        private readonly IGetUsersByRoleUseCase _getByRol;
        private readonly IGetUsersByNameUseCase _getByName;

        public UserController(IGetAllUsersUseCase getAll,
                              IGetUserByIdUseCase getById,
                              IDeleteUserUseCase delete,
                              IUpdateUserUseCase update,
                              ISaveUserUseCase save,
                              IGetUsersByRoleUseCase getByRol,
                              IGetUsersByNameUseCase getByName)
        {
            _getAll = getAll;
            _getById = getById;
            _delete = delete;
            _update = update;
            _save = save;
            _getByRol = getByRol;
            _getByName = getByName;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDTO>))]
        public async Task<ActionResult> GetAll()
        {
            var data = await _getAll.Call(null);
            return Ok(data);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(UserDTO))]
        public async Task<ActionResult> GetById(Guid id)
        {
            var data = await _getById.Call(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> PostUsuario(UserDTO? dto)
        {
            return Ok(await _save.Call(dto));
        }

        [HttpPut]
        public async Task<ActionResult> PutUsuario(UserDTO model)
        {
            var data = await _update.Call(model);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(Guid id)
        {
            var data = await _delete.Call(id);

            return Ok(data);
        }
        // Aplicar a las demas capas
        [HttpGet("ByRol/{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDTO>))]
        public async Task<ActionResult> GetByRol(Guid id)
        {
            return Ok(await _getByRol.Call(id));
        }

        [HttpGet("ByName/{name}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDTO>))]
        public async Task<ActionResult> GetByName(string name)
        {
            return Ok(await _getByName.Call(name));
        }
    }
}
