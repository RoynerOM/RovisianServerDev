using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Services;

namespace RovisianServerDev.Domain.UseCases.User
{
    public interface IDeleteUserUseCase : IUseCase<DataState<bool>, Guid>
    {

    }

    public class DeleteUser : IDeleteUserUseCase
    {
        private readonly IUsuarioService _userService;
        public DeleteUser(IUsuarioService userService)
        {
            this._userService = userService;
        }

        public async Task<DataState<bool>> Call(Guid values) => await _userService.Delete(values);

    }
}
