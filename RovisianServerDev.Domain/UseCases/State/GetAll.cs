using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Services;

namespace RovisianServerDev.Domain.UseCases.State
{
    public interface IGetAllStatesUseCase : IUseCase<DataState<IEnumerable<EstadoEntity>>, object>
    {

    }

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
