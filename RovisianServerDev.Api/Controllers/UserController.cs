﻿using Microsoft.AspNetCore.Mvc;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Application.UseCases.User;

namespace RovisianServerDev.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGetAllUsersUseCase _getAllUsers;
        private readonly IGetByIdUserUseCase _getByIdUser;
        private readonly IDeleteUserUseCase _deleteUser;
        private readonly IUpdateUserUseCase _updateUser;
        private readonly ISaveUserUseCase _saveUser;
     
        public UserController(IGetAllUsersUseCase getAllUsers, IGetByIdUserUseCase getByIdUserUseCase, IDeleteUserUseCase deleteUserUseCase, IUpdateUserUseCase updateUserUseCase, ISaveUserUseCase saveUserUseCase)
        {
            this._getAllUsers = getAllUsers;
            this._getByIdUser = getByIdUserUseCase;
            this._deleteUser = deleteUserUseCase;
            this._updateUser = updateUserUseCase;
            this._saveUser = saveUserUseCase;
        }

        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<UserDTO>))]
        public async Task<ActionResult> GetAll()
        {
            var data = await _getAllUsers.Call(null);
            return Ok(data);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(UserDTO))]
        public async Task<ActionResult> GetById(Guid id)
        {
            var data = await _getByIdUser.Call(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> PostUsuario(UserDTO? dto)
        {
            return Ok(await _saveUser.Call(dto));
        }

        [HttpPut]
        public async Task<ActionResult> PutUsuario(Guid id, UserDTO model)
        {
            model.Id = id;

            var data = await _updateUser.Call(model);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(Guid id)
        {
            var data = await _deleteUser.Call(id);

            return Ok(data);
        }
    }
}
