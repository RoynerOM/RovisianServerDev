using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Application.DTOs;
using AutoMapper;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.User
{
    public interface IGetByIdUserUseCase : IUseCase<UserDTO, Guid> {}

    public class GetByIdUser : IGetByIdUserUseCase
    {
        private readonly IUsuarioService _userService;
        private readonly IMapper _mapper;

        public GetByIdUser(IUsuarioService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }

        public async Task<UserDTO> Call(Guid values)
        {
            UsuarioEntity userEntity = await _userService.GetById(values);
            return _mapper.Map<UserDTO>(userEntity);
        }
    }
}
