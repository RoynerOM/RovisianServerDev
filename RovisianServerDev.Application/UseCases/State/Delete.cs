using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.State
{
    public interface IDeleteStatesUseCase : IUseCase<bool, Guid> {}

    public class DeleteStateCase : IDeleteStatesUseCase
    {
        private readonly IStateService _stateService;
        public DeleteStateCase(IStateService stateService)
        {
            this._stateService = stateService;
        }

        public async Task<bool> Call(Guid values) => await _stateService.Delete(values);
    }
}
