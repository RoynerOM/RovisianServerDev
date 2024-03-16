using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Application.DTOs;
using AutoMapper;
using RovisianServerDev.Domain.Error;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.User
{
    public interface ISaveUserUseCase : IUseCase<Task, UserDTO>{}

    public class SaveUser : ISaveUserUseCase
    {
        private readonly IUsuarioService _userService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        public SaveUser(IUsuarioService userService, IMapper mapper, IPasswordService passwordService)
        {
            this._userService = userService;
            this._mapper = mapper;
            this._passwordService = passwordService;
        }


        public async Task<Task> Call(UserDTO? values)
        {
            byte[] salt = _passwordService.GenerateSalt();

            if (values == null)
            {
                throw new ParamNullException("UserDTO no puede ser nulo.");
            }

            UsuarioEntity userEntity = _mapper.Map<UsuarioEntity>(values);

            userEntity.Contrasenna = _passwordService.Hash(values.Contrasenna,salt);
            userEntity.Firma = Convert.ToBase64String(salt);

            await _userService.Save(userEntity);
            return Task.FromResult(true);
        }
    }
}
