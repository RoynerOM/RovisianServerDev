using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;
using AutoMapper;
using RovisianServerDev.Application.DTOs;

namespace RovisianServerDev.Application.UseCases.Banco
{
    public interface IGetByIdBancoUseCase : IUseCase<BankDTO, Guid> { }

    public class GetByIdBancoCase : IGetByIdBancoUseCase
    {
        private readonly IBancoService _bancoService;
        private readonly IMapper _mapper;
        public GetByIdBancoCase(IBancoService bancoService, IMapper mapper)
        {
            this._bancoService = bancoService;
            this._mapper = mapper;
        }

        public async Task<BankDTO> Call(Guid values) => _mapper.Map<BankDTO>(await _bancoService.GetById(values));
    }
}
