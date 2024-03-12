using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RovisianServerDev.Core.DTOs;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.UseCases.User;

namespace RovisianServerDev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGetAllUsersUseCase _getAllUsers;
        private readonly IGetByIdUserUseCase _getByIdUser;
        private readonly IDeleteUserUseCase _deleteUser;
        private readonly IUpdateUserUseCase _updateUser;
        private readonly ISaveUserUseCase _saveUser;
        private readonly IMapper _mapper;
        public UserController(IGetAllUsersUseCase getAllUsers, IGetByIdUserUseCase getByIdUserUseCase, IDeleteUserUseCase deleteUserUseCase, IUpdateUserUseCase updateUserUseCase, ISaveUserUseCase saveUserUseCase, IMapper mapper)
        {
            this._getAllUsers = getAllUsers;
            this._getByIdUser = getByIdUserUseCase;
            this._deleteUser = deleteUserUseCase;
            this._updateUser = updateUserUseCase;
            this._saveUser = saveUserUseCase;
            this._mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var data = await _getAllUsers.Call(null);
            return Ok(_mapper.Map<IEnumerable<UserDTO>>(data.Data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var data = await _getByIdUser.Call(id);
            return Ok(_mapper.Map<UserDTO>(data.Data));
        }

        [HttpPost]
        public async Task<ActionResult> PostUsuario(UserDTO model) => Ok(await _saveUser.Call(_mapper.Map<UsuarioEntity>(model)));

        [HttpPut]
        public async Task<ActionResult> PutUsuario(UserDTO model) => Ok(await _updateUser.Call(_mapper.Map<UsuarioEntity>(model)));

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(Guid id) => Ok(await _deleteUser.Call(id));
    }
}
