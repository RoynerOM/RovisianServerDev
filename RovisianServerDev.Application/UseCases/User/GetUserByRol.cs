using AutoMapper;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.User
{
    using UserDTOList = IEnumerable<UserDTO>;

    public interface IGetUsersByRolUseCase : IUseCase<UserDTOList, Guid> { }

    public class GetUsersByRolUseCase : IGetUsersByRolUseCase
    {
        private readonly IUsuarioService _userService;
        private readonly IMapper _mapper;
        public GetUsersByRolUseCase(IUsuarioService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }

        public async Task<UserDTOList> Call(Guid rolId)
        {
            IEnumerable<UsuarioEntity> usersEntities = await _userService.GetByRol(rolId);
            return _mapper.Map<UserDTOList>(usersEntities);
        }
    }
}
