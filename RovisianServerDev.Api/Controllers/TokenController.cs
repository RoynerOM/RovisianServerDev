using Microsoft.AspNetCore.Mvc;
using RovisianServerDev.Application.UseCases.Security;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.UseCases.User;

namespace RovisianServerDev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ICreateTokenUseCase _createToken;
        private readonly IIsValidUserUseCase _isValidIser;

        public TokenController(ICreateTokenUseCase createToken, IIsValidUserUseCase isValidUser)
        {
            this._createToken = createToken;
            this._isValidIser = isValidUser;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(UserLogin userLogin)
        {
            var validation = await _isValidIser.Call(userLogin);

            if (validation.Item1)
            {
                var token = await _createToken.Call(validation.Item2);

                return Ok(new { token });
            }

            return NotFound();
        }
    }
}
