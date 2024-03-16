using RovisianServerDev.Domain.Resources;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.Banco
{
    public interface ISaveBancoUseCase : IUseCase<DataState<Task>, BancoEntity>{}

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
