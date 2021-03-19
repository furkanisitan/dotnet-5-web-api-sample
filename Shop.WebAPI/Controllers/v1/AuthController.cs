using Microsoft.AspNetCore.Mvc;
using Shop.Business.Abstract;
using Shop.WebAPI.Models.Auth;
using Shop.WebAPI.Utilities.Extensions;

namespace Shop.WebAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(AuthenticateRequest model)
        {
            var (serviceResult, user) = _authService.Login(model.UserName, model.Password);
            if (!serviceResult.IsSuccess) return this.FailedFromServiceResult(serviceResult);

            var token = _authService.CreateToken(user);
            return Ok(token);
        }
    }
}
