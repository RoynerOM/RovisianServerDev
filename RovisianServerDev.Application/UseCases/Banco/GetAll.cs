using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;
using AutoMapper;
using RovisianServerDev.Application.DTOs;

namespace RovisianServerDev.Application.UseCases.Banco
{
    public interface IGetAllBancoUseCase : IUseCase<IEnumerable<BankDTO>, object> { }

    public class GetAllBancoCase : IGetAllBancoUseCase
    {
        private readonly IBancoService _bancoService;
        private readonly IMapper _mapper;
        public GetAllBancoCase(IBancoService bancoService, IMapper mapper)
        {
            this._bancoService = bancoService;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<BankDTO>> Call(object? values) => _mapper.Map<IEnumerable<BankDTO>>(await _bancoService.GetAll());
    }
}
