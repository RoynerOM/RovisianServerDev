using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Application.DTOs;
using AutoMapper;
using RovisianServerDev.Domain.Error;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.User
{
    public interface IUpdateUserUseCase : IUseCase<bool, UserDTO>{}

    public class UpdateUser : IUpdateUserUseCase
    {
        private readonly IUsuarioService _userService;
        private readonly IMapper _mapper;

        public UpdateUser(IUsuarioService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }

        public async Task<bool> Call(UserDTO? dto)
        {

            if (dto == null)
            {
                throw new ParamNullException("UserDTO no puede ser nulo.");
            }

            UsuarioEntity user = _mapper.Map<UsuarioEntity>(dto);
            return await _userService.Update(user);
        }
    }
}
