using RovisianServerDev.Domain.Resources;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.State
{
    public interface ISaveStatesUseCase : IUseCase<DataState<Task>, EstadoEntity>{}

    public class SaveStateCase : ISaveStatesUseCase
    {
        private readonly IStateService _stateService;
        public SaveStateCase(IStateService stateService)
        {
            this._stateService = stateService;
        }

        public async Task<DataState<Task>> Call(EstadoEntity? values) => await _stateService.SaveState(values!);

    }
}
