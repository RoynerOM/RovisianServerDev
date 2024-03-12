using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Services;

namespace RovisianServerDev.Domain.UseCases.Banco
{
    public interface IGetByIdBancoUseCase : IUseCase<DataState<BancoEntity>, Guid>
    {

    }

    public class GetByIdBancoCase : IGetByIdBancoUseCase
    {
        private readonly IBancoService _bancoService;
        public GetByIdBancoCase(IBancoService bancoService)
        {
            this._bancoService = bancoService;
        }

        public async Task<DataState<BancoEntity>> Call(Guid values) => await _bancoService.GetById(values);

    }
}
