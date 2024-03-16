using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using AutoMapper;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.User
{
    using UserDTOList = IEnumerable<UserDTO>;

    public interface IGetAllUsersUseCase : IUseCase<UserDTOList, object>{}

    public class GetAllUsers : IGetAllUsersUseCase
    {
        private readonly IUsuarioService _userService;
        private readonly IMapper _mapper;
        public GetAllUsers(IUsuarioService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }

        public async Task<UserDTOList> Call(object? values)
        {
            IEnumerable<UsuarioEntity> usersEntities = await _userService.GetAll();
            return _mapper.Map<UserDTOList>(usersEntities);
        }
    }
}
