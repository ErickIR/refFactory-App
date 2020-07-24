using CRD.AplicationCore.Interfaces;
using CRD.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CRD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost]
        public IActionResult ValidateCredentials(LoginDto loginDto)
        {
            var result = loginService.ValidateLogin(loginDto);

            return Ok(result);
        }
    }
}
