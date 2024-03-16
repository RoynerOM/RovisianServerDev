using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;
using RovisianServerDev.Application.DTOs;
using AutoMapper;

namespace RovisianServerDev.Application.UseCases.State
{
    public interface IGetByIdStatesUseCase : IUseCase<StateDTO, Guid> { }

    public class GetByIdStateCase : IGetByIdStatesUseCase
    {
        private readonly IStateService _stateService;
        private readonly IMapper _mapper;

        public GetByIdStateCase(IStateService stateService, IMapper mapper)
        {
            this._stateService = stateService;
            this._mapper = mapper;
        }

        public async Task<StateDTO> Call(Guid values) => _mapper.Map<StateDTO>(await _stateService.GetById(values));
    }
}
