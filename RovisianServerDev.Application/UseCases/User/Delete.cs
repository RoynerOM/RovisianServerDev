using RovisianServerDev.Domain.Interfaces;
using RovisianServerDev.Domain.Interfaces.Services;

namespace RovisianServerDev.Application.UseCases.User
{
    public interface IDeleteUserUseCase : IUseCase<bool, Guid>{}

    public class DeleteUser : IDeleteUserUseCase
    {
        private readonly IUsuarioService _userService;
        public DeleteUser(IUsuarioService userService)
        {
            this._userService = userService;
        }

        public async Task<bool> Call(Guid values)
        {
            return await _userService.Delete(values);
        }
    }
}
