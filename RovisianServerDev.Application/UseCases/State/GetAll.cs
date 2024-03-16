using RovisianServerDev.Domain.Resources;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.State
{
    public interface IGetAllStatesUseCase : IUseCase<DataState<IEnumerable<EstadoEntity>>, object> {}

    public class GetAll : IGetAllStatesUseCase
    {
        private readonly IStateService _stateService;
        public GetAll(IStateService stateService)
        {
            this._stateService = stateService;
        }

        public async Task<DataState<IEnumerable<EstadoEntity>>> Call(object? values) => await _stateService.GetAll();

    }
}
