using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;
using AutoMapper;
using RovisianServerDev.Application.DTOs;

namespace RovisianServerDev.Application.UseCases.State
{
    public interface IGetAllStatesUseCase : IUseCase<IEnumerable<StateDTO>, object> { }

    public class GetAll : IGetAllStatesUseCase
    {
        private readonly IStateService _stateService;
        private readonly IMapper _mapper;

        public GetAll(IStateService stateService, IMapper mapper)
        {
            this._stateService = stateService;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<StateDTO>> Call(object? values) => _mapper.Map<IEnumerable<StateDTO>>(await _stateService.GetAll());
    }
}
