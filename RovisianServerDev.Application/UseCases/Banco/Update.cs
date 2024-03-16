using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;
using AutoMapper;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Domain.Error;

namespace RovisianServerDev.Application.UseCases.Banco
{
    public interface IUpdateBancoUseCase : IUseCase<bool, BankDTO> { }

    public class UpdateBancoCase : IUpdateBancoUseCase
    {
        private readonly IBancoService _bancoService;
        private readonly IMapper _mapper;
        public UpdateBancoCase(IBancoService bancoService, IMapper mapper)
        {
            this._bancoService = bancoService;
            this._mapper = mapper;
        }

        public async Task<bool> Call(BankDTO? dto)
        {
            if (dto == null)
            {
                throw new ParamNullException("Bank no puede ser nulo.");
            }

            return await _bancoService.Update(_mapper.Map<BancoEntity>(dto));
        }
    }
}
