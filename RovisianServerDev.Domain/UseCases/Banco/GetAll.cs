using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Services;

namespace RovisianServerDev.Domain.UseCases.Banco
{
    public interface IGetAllBancoUseCase : IUseCase<DataState<IEnumerable<BancoEntity>>, object>
    {

    }

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
