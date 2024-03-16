using RovisianServerDev.Domain.Resources;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.State
{
    public interface IUpdateStatesUseCase : IUseCase<DataState<bool>, EstadoEntity>{}

    public class UpdateStateCase : IUpdateStatesUseCase
    {
        private readonly IStateService _stateService;
        public UpdateStateCase(IStateService stateService)
        {
            this._stateService = stateService;
        }

        public async Task<DataState<bool>> Call(EstadoEntity? values) => await _stateService.UpdateState(values!);

    }
}
