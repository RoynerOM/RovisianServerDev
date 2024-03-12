using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Services;

namespace RovisianServerDev.Domain.UseCases.Banco
{
    public interface IDeleteBancoUseCase : IUseCase<DataState<bool>, Guid>
    {

    }

    public class DeleteBancoCase : IDeleteBancoUseCase
    {
        private readonly IBancoService _bancoService;
        public DeleteBancoCase(IBancoService bancoService)
        {
            this._bancoService = bancoService;
        }

        public async Task<DataState<bool>> Call(Guid values) => await _bancoService.Delete(values);

    }
}
