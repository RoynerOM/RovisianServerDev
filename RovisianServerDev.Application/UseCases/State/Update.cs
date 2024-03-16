using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;
using AutoMapper;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Domain.Error;

namespace RovisianServerDev.Application.UseCases.State
{
    public interface IUpdateStatesUseCase : IUseCase<bool, StateDTO> { }

    public class UpdateStateCase : IUpdateStatesUseCase
    {
        private readonly IStateService _stateService;
        private readonly IMapper _mapper;

        public UpdateStateCase(IStateService stateService, IMapper mapper)
        {
            this._stateService = stateService;
            this._mapper = mapper;
        }

        public async Task<bool> Call(StateDTO? dto)
        {
            if (dto == null)
            {
                throw new ParamNullException("StateDTO no puede ser nulo.");
            }

            return await _stateService.Update(_mapper.Map<EstadoEntity>(dto));
        }
    }
}
