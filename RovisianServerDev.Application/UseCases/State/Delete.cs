using RovisianServerDev.Domain.Resources;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.State
{
    public interface IDeleteStatesUseCase : IUseCase<DataState<bool>, Guid> {}

    public class DeleteStateCase : IDeleteStatesUseCase
    {
        private readonly IStateService _stateService;
        public DeleteStateCase(IStateService stateService)
        {
            this._stateService = stateService;
        }

        public async Task<DataState<bool>> Call(Guid values) => await _stateService.DeleteState(values);

    }
}
