using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Domain.Resources;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Application.UseCases.State;

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
        private readonly IMapper _mapper;
        public StateController(IGetAllStatesUseCase getAllStates, IGetByIdStatesUseCase getByIdStatesUseCase, ISaveStatesUseCase saveStatesUseCase, IUpdateStatesUseCase updateStatesUseCase, IDeleteStatesUseCase deleteStatesUseCase, IMapper mapper)
        {
            this._getAllStatesUseCase = getAllStates;
            this._getByIdStatesUseCase = getByIdStatesUseCase;
            this._saveStatesUseCase = saveStatesUseCase;
            this._updateStatesUseCase = updateStatesUseCase;
            this._deleteStatesUseCase = deleteStatesUseCase;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var data = await _getAllStatesUseCase.Call(null);
            return Ok(_mapper.Map<IEnumerable<StateDTO>>(data.Data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            DataState<EstadoEntity> dataState = await _getByIdStatesUseCase.Call(id);
            return Ok(dataState.ToJson());
        }

        [HttpPost]
        public async Task<ActionResult> Save(EstadoEntity e)
        {
            DataState<Task> dataState = await _saveStatesUseCase.Call(e);
            return Ok(dataState.ToJson());
        }

        [HttpPut]
        public async Task<ActionResult> Update(EstadoEntity e)
        {
            DataState<bool> dataState = await _updateStatesUseCase.Call(e);
            return Ok(dataState.ToJson());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            DataState<bool> dataState = await _deleteStatesUseCase.Call(id);
            return Ok(dataState.ToJson());
        }
    }
}
