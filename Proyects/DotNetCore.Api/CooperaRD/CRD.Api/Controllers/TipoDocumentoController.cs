using CRD.AplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        readonly ITipoDocumentoService tipoDocumentoService;

        public TipoDocumentoController(ITipoDocumentoService tipoDocumentoService)
        {
            this.tipoDocumentoService = tipoDocumentoService;
        }

        [HttpGet]
        public IActionResult GetAllTiposDocumento()
        {
            var result = tipoDocumentoService.GetAllTiposDocumento();

            return Ok(result);
        }

        [HttpGet("{tipoDocumentoId}")]
        public IActionResult GetAllTipoDocumentoByTipoDocumentoId(int tipoDocumentoId)
        {
            var result = tipoDocumentoService.GetAllTipoDocumentoByTipoDocumentoId(tipoDocumentoId);

            return Ok(result);
        }
    }
}
