using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Services;

namespace RovisianServerDev.Domain.UseCases.User
{
    public interface IGetByIdUserUseCase : IUseCase<DataState<UsuarioEntity>, Guid>
    {

    }

    public class GetByIdUser : IGetByIdUserUseCase
    {
        private readonly IUsuarioService _userService;
        public GetByIdUser(IUsuarioService userService)
        {
            this._userService = userService;
        }

        public async Task<DataState<UsuarioEntity>> Call(Guid values) => await _userService.GetById(values);


    }
}
