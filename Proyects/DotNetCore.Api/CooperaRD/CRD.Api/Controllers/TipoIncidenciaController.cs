using CRD.AplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIncidenciaController : ControllerBase
    {
        readonly ITipoIncidenciaService tipoIncidenciaService;

        public TipoIncidenciaController(ITipoIncidenciaService tipoIncidenciaService)
        {
            this.tipoIncidenciaService = tipoIncidenciaService;
        }

        [HttpGet]
        public IActionResult GetAllTiposIncidencias()
        {
            var result = tipoIncidenciaService.GetAllTiposIncidencias();

            return Ok(result);
        }

        [HttpGet("{tipoIncidenciaId}")]
        public IActionResult GetTipoIncidenciaByTipoIncidenciaId(int tipoIncidenciaId)
        {
            var result = tipoIncidenciaService.GetTipoIncidenciaByTipoIncidenciaId(tipoIncidenciaId);

            return Ok(result);
        }

    }
}
