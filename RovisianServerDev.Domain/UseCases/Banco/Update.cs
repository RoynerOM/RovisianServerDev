using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Services;

namespace RovisianServerDev.Domain.UseCases.Banco
{
    public interface IUpdateBancoUseCase : IUseCase<DataState<bool>, BancoEntity>
    {

    }

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
