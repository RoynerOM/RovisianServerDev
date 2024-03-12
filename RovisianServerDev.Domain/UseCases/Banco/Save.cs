using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Services;

namespace RovisianServerDev.Domain.UseCases.Banco
{
    public interface ISaveBancoUseCase : IUseCase<DataState<Task>, BancoEntity>
    {

    }

    public class SaveBancoCase : ISaveBancoUseCase
    {
        private readonly IBancoService _bancoService;
        public SaveBancoCase(IBancoService bancoService)
        {
            this._bancoService = bancoService;
        }

        public async Task<DataState<Task>> Call(BancoEntity? values) => await _bancoService.Save(values!);

    }
}
