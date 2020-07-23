using CRD.AplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        readonly IRolService rolService;

        public RolController(IRolService rolService)
        {
            this.rolService = rolService;
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var result = rolService.GetAllRoles();

            return Ok(result);
        }

        [HttpGet("{rolId}")]
        public IActionResult GetRolByRolId(int rolId)
        {
            var result = rolService.GetRolByRolId(rolId);
                
            return Ok(result);
        }
    }
}
