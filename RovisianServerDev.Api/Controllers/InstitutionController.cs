using Microsoft.AspNetCore.Mvc;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Application.UseCases.Institution;

namespace RovisianServerDev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionController : ControllerBase
    {
        private readonly IGetAllInstitutionUseCase _getAll;
        private readonly IGetByIdInstitutionUseCase _getById;
        private readonly IDeleteInstitutionUseCase _delete;
        private readonly IUpdateInstitutionUseCase _update;
        private readonly ISaveInstitutionUseCase _save;
        private readonly IGetByCodeInstitutionUseCase _getByCode;
        private readonly IGetByNameInstitutionUseCase _getByName;
        public InstitutionController(IGetAllInstitutionUseCase getAll, IGetByIdInstitutionUseCase getById, IDeleteInstitutionUseCase delete, IUpdateInstitutionUseCase update, ISaveInstitutionUseCase save, IGetByCodeInstitutionUseCase getByCode, IGetByNameInstitutionUseCase getByName)
        {
            this._getAll = getAll;
            this._getById = getById;
            this._delete = delete;
            this._update = update;
            this._save = save;
            this._getByCode = getByCode;
            this._getByName = getByName;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() => Ok(await _getAll.Call(null));

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id) => Ok(await _getById.Call(id));

        [HttpGet("ByCode/{code}")]
        public async Task<ActionResult> GetByCode(int code) => Ok(await _getByCode.Call(code));

        [HttpGet("ByName/{name}")]
        public async Task<ActionResult> GetByName(string name) => Ok(await _getByName.Call(name));

        [HttpPost]
        public async Task<ActionResult> PostInstitution(InstitutionDTO dto) => Ok(await _save.Call(dto));

        [HttpPut]
        public async Task<ActionResult> PutInstitution(InstitutionDTO dto) => Ok(await _update.Call(dto));

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInstitution(Guid id) => Ok(await _delete.Call(id));
    }
}
