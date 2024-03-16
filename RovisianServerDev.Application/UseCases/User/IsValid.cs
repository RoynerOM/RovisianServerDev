using AutoMapper;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Error;
using RovisianServerDev.Domain.Interfaces;
using RovisianServerDev.Domain.Interfaces.Services;

namespace RovisianServerDev.Domain.UseCases.User
{
    public interface IIsValidUserUseCase : IUseCase<(bool, UserDTO?), UserLogin> { }

    public class IsValidUser : IIsValidUserUseCase
    {
        private readonly IUsuarioService _userService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        public IsValidUser(IUsuarioService userService, IMapper mapper, IPasswordService passwordService)
        {
            this._userService = userService;
            this._mapper = mapper;
            this._passwordService = passwordService;

        }

        public async Task<(bool, UserDTO?)> Call(UserLogin? userLogin)
        {
            if (userLogin == null)
            {
                throw new ParamNullException("UserLogin no puede ser nulo.");
            }

            UsuarioEntity userEntity = await _userService.GetLogin(userLogin.Id);

            byte[] salt = Convert.FromBase64String(userEntity.Firma);
            bool isValid = _passwordService.Verify(userLogin.Password,userEntity.Contrasenna, salt);

            UserDTO? userDTO = _mapper.Map<UserDTO>(userEntity);
            return (isValid, userDTO);
        }
    }
}
