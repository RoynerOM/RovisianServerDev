using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Services;

namespace RovisianServerDev.Domain.UseCases.User
{
    public interface IGetAllUsersUseCase : IUseCase<DataState<IEnumerable<UsuarioEntity>>, object>
    {

    }

    public class GetAllUsers : IGetAllUsersUseCase
    {
        private readonly IUsuarioService _userService;
        public GetAllUsers(IUsuarioService userService)
        {
            this._userService = userService;
        }

        public async Task<DataState<IEnumerable<UsuarioEntity>>> Call(object? values) => await _userService.GetAll();

    }
}
