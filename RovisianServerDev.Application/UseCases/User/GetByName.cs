using AutoMapper;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.User
{
    using UserDTOList = IEnumerable<UserDTO>;

    public interface IGetUsersByNameUseCase : IUseCase<UserDTOList, string> { }

    public class GetUsersNameUseCase : IGetUsersByNameUseCase
    {
        private readonly IUsuarioService _userService;
        private readonly IMapper _mapper;
        public GetUsersNameUseCase(IUsuarioService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }

        public async Task<UserDTOList> Call(string? name)
        {
            IEnumerable<UsuarioEntity> usersEntities = await _userService.GetByName(name??"");
            return _mapper.Map<UserDTOList>(usersEntities);
        }
    }
}
