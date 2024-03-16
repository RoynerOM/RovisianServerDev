using RovisianServerDev.Domain.Resources;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.Banco
{
    public interface IGetAllBancoUseCase : IUseCase<DataState<IEnumerable<BancoEntity>>, object>{}

    public class GetAllBancoCase : IGetAllBancoUseCase
    {
        private readonly IBancoService _bancoService;
        public GetAllBancoCase(IBancoService bancoService)
        {
            this._bancoService = bancoService;
        }

        public async Task<DataState<IEnumerable<BancoEntity>>> Call(object? values) => await _bancoService.GetAll();

    }
}
