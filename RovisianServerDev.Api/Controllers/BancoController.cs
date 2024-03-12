using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.UseCases.Banco;
using RovisianServerDev.Domain.UseCases.Rol;

namespace RovisianServerDev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly IGetAllBancoUseCase _getAllBancoCase;
        private readonly IGetByIdBancoUseCase _getByIdBancoUseCase;
        private readonly IDeleteBancoUseCase _deleteBancoUseCase;
        private readonly IUpdateBancoUseCase _updateBancoUseCase;
        private readonly ISaveBancoUseCase _saveBancoUseCase;
        public BancoController(IGetAllBancoUseCase getAllBancoUseCase, IGetByIdBancoUseCase getByIdBancoUseCase, IDeleteBancoUseCase deleteBancoUseCase, IUpdateBancoUseCase updateBancoUseCase, ISaveBancoUseCase saveBancoUseCase)
        {
            this._getAllBancoCase = getAllBancoUseCase;
            this._getByIdBancoUseCase = getByIdBancoUseCase;
            this._deleteBancoUseCase = deleteBancoUseCase;
            this._updateBancoUseCase = updateBancoUseCase;
            this._saveBancoUseCase = saveBancoUseCase;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll() => Ok(await _getAllBancoCase.Call(null));

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id) => Ok(await _getByIdBancoUseCase.Call(id));

        [HttpPost]
        public async Task<ActionResult> PostRol(BancoEntity model) => Ok(await _saveBancoUseCase.Call(model));

        [HttpPut]
        public async Task<ActionResult> PutRol(BancoEntity model) => Ok(await _updateBancoUseCase.Call(model));

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRol(Guid id) => Ok(await _deleteBancoUseCase.Call(id));
    }
}
