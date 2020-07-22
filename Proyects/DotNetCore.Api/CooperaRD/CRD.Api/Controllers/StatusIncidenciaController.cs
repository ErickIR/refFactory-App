using CRD.AplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusIncidenciaController : ControllerBase
    {
        readonly IStatusIncidenciaService statusIncidenciaService;

        public StatusIncidenciaController(IStatusIncidenciaService statusIncidenciaService)
        {
            this.statusIncidenciaService = statusIncidenciaService;
        }

        [HttpGet]
        public IActionResult GetAllStatusIncidencias()
        {
            var result = statusIncidenciaService.GetAllStatusIncidencias();

            return Ok(result);
        }

        [HttpGet("{statusIncidenciaId}")]
        public IActionResult GetStatusIncidenciaByStatusIncidenciaId(int statusIncidenciaId)
        {
            var result = statusIncidenciaService.GetStatusIncidenciaByStatusIncidenciaId(statusIncidenciaId);

            return Ok(result);
        }
    }
}
