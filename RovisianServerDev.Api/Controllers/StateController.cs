using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RovisianServerDev.Application.DTOs;
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
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            return Ok(await _getByIdStatesUseCase.Call(id));
        }

        [HttpPost]
        public async Task<ActionResult> Save(StateDTO e)
        {
            return Ok(await _saveStatesUseCase.Call(e));
        }

        [HttpPut]
        public async Task<ActionResult> Update(StateDTO e)
        {
            return Ok(await _updateStatesUseCase.Call(e));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return Ok(await _deleteStatesUseCase.Call(id));
        }
    }
}
