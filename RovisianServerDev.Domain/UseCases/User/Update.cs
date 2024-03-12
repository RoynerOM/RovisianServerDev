using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Services;

namespace RovisianServerDev.Domain.UseCases.User
{
    public interface IUpdateUserUseCase : IUseCase<DataState<bool>, UsuarioEntity>
    {

    }

    public class UpdateUser : IUpdateUserUseCase
    {
        private readonly IUsuarioService _userService;
        public UpdateUser(IUsuarioService userService)
        {
            this._userService = userService;
        }

        public async Task<DataState<bool>> Call(UsuarioEntity? values) => await _userService.Update(values!);

    }
}
