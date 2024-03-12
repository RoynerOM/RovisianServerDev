using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Services;


namespace RovisianServerDev.Domain.UseCases.User
{
    public interface ISaveUserUseCase : IUseCase<DataState<Task>, UsuarioEntity>
    {

    }

    public class SaveUser : ISaveUserUseCase
    {
        private readonly IUsuarioService _userService;
        public SaveUser(IUsuarioService userService)
        {
            this._userService = userService;
        }


        public async Task<DataState<Task>> Call(UsuarioEntity? values) => await _userService.Save(values!);

    }
}
