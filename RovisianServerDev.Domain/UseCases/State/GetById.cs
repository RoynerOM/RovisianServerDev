using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Services;

namespace RovisianServerDev.Domain.UseCases.State
{
    public interface IGetByIdStatesUseCase : IUseCase<DataState<EstadoEntity>, Guid>
    {

    }

    public class GetByIdStateCase : IGetByIdStatesUseCase
    {
        private readonly IStateService _stateService;
        public GetByIdStateCase(IStateService stateService)
        {
            this._stateService = stateService;
        }

        public async Task<DataState<EstadoEntity>> Call(Guid values) => await _stateService.GetById(values);


    }
}
