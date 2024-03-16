using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;
using RovisianServerDev.Domain.Error;
using RovisianServerDev.Application.DTOs;
using AutoMapper;

namespace RovisianServerDev.Application.UseCases.State
{
    public interface ISaveStatesUseCase : IUseCase<Task, StateDTO> { }

    public class SaveStateCase : ISaveStatesUseCase
    {
        private readonly IStateService _stateService;
        private readonly IMapper _mapper;

        public SaveStateCase(IStateService stateService, IMapper mapper)
        {
            this._stateService = stateService;
            this._mapper = mapper;
        }

        public async Task<Task> Call(StateDTO? dto)
        {
            if (dto == null)
            {
                throw new ParamNullException("StateDTO no puede ser nulo.");
            }

            await _stateService.Save(_mapper.Map<EstadoEntity>(dto));
            return Task.CompletedTask;
        }
    }
}
