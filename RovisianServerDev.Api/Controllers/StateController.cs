using Microsoft.AspNetCore.Mvc;
using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.UseCases.State;


namespace RovisianServerDev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IGetAllStatesUseCase _getAllStatesUseCase;
        private readonly IGetByIdStatesUseCase _getByIdStatesUseCase;
        private readonly ISaveStatesUseCase _saveStatesUseCase;
        private readonly IUpdateStatesUseCase _updateStatesUseCase;
        private readonly IDeleteStatesUseCase _deleteStatesUseCase;
        public StateController(IGetAllStatesUseCase getAllStates, IGetByIdStatesUseCase getByIdStatesUseCase, ISaveStatesUseCase saveStatesUseCase, IUpdateStatesUseCase updateStatesUseCase, IDeleteStatesUseCase deleteStatesUseCase)
        {
            this._getAllStatesUseCase = getAllStates;
            this._getByIdStatesUseCase = getByIdStatesUseCase;
            this._saveStatesUseCase = saveStatesUseCase;
            this._updateStatesUseCase = updateStatesUseCase;
            this._deleteStatesUseCase = deleteStatesUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            DataState<IEnumerable<EstadoEntity>> dataState = await _getAllStatesUseCase.Call(null);
            watch.Stop();
            dataState.RequestTime = watch.ElapsedMilliseconds;

            return Ok(dataState.ToJson());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            DataState<EstadoEntity> dataState = await _getByIdStatesUseCase.Call(id);
            watch.Stop();
            dataState.RequestTime = watch.ElapsedMilliseconds;

            return Ok(dataState.ToJson());
        }


        [HttpPost]
        public async Task<ActionResult> Save(EstadoEntity e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            DataState<Task> dataState = await _saveStatesUseCase.Call(e);
            watch.Stop();
            dataState.RequestTime = watch.ElapsedMilliseconds;

            return Ok(dataState.ToJson());
        }


        [HttpPut]
        public async Task<ActionResult> Update(EstadoEntity e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            DataState<bool> dataState = await _updateStatesUseCase.Call(e);
            watch.Stop();
            dataState.RequestTime = watch.ElapsedMilliseconds;

            return Ok(dataState.ToJson());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            DataState<bool> dataState = await _deleteStatesUseCase.Call(id);
            watch.Stop();
            dataState.RequestTime = watch.ElapsedMilliseconds;

            return Ok(dataState.ToJson());
        }

    }
}
