using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;
using RovisianServerDev.Domain.Error;
using RovisianServerDev.Application.DTOs;
using AutoMapper;

namespace RovisianServerDev.Application.UseCases.Banco
{
    public interface ISaveBancoUseCase : IUseCase<Task, BankDTO> { }

    public class SaveBancoCase : ISaveBancoUseCase
    {
        private readonly IBancoService _bancoService;
        private readonly IMapper _mapper;
        public SaveBancoCase(IBancoService bancoService, IMapper mapper)
        {
            this._bancoService = bancoService;
            this._mapper = mapper;
        }

        public async Task<Task> Call(BankDTO? dto)
        {
            if (dto == null)
            {
                throw new ParamNullException("Bank no puede ser nulo.");
            }

            await _bancoService.Save(_mapper.Map<BancoEntity>(dto));
            return Task.CompletedTask;
        }
    }
}
