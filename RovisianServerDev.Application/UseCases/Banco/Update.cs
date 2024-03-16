using RovisianServerDev.Domain.Resources;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.Banco
{
    public interface IUpdateBancoUseCase : IUseCase<DataState<bool>, BancoEntity>{}

    public class UpdateBancoCase : IUpdateBancoUseCase
    {
        private readonly IBancoService _bancoService;
        public UpdateBancoCase(IBancoService bancoService)
        {
            this._bancoService = bancoService;
        }

        public async Task<DataState<bool>> Call(BancoEntity? values) => await _bancoService.Update(values!);

    }
}
