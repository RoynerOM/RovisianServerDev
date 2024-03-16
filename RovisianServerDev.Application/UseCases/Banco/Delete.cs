using RovisianServerDev.Domain.Interfaces;
using RovisianServerDev.Domain.Interfaces.Services;

namespace RovisianServerDev.Application.UseCases.Banco
{
    public interface IDeleteBancoUseCase : IUseCase<bool, Guid>{}

    public class DeleteBancoCase : IDeleteBancoUseCase
    {
        private readonly IBancoService _bancoService;
        public DeleteBancoCase(IBancoService bancoService)
        {
            this._bancoService = bancoService;
        }

        public async Task<bool> Call(Guid values) => await _bancoService.Delete(values);
    }
}
