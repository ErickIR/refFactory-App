using CRD.AplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeccionController : ControllerBase
    {
        readonly ISeccionService seccionService;

        public SeccionController(ISeccionService seccionService) 
        {
            this.seccionService = seccionService;
        }

        [HttpGet]
        public IActionResult GetAllSecciones()
        {
            var result = seccionService.GetAllSecciones();

            return Ok(result);
        }

        [HttpGet("{seccionId}")]
        public IActionResult GetSeccionBySeccionId(int seccionId)
        {
            var result = seccionService.GetSeccionBySeccionId(seccionId);

            return Ok(result);
        }
        
        [HttpGet("distrito-municipal/{distritoMunicipalId}")]
        public IActionResult GetAllSeccionesByDistritoMunicipalId(int distritoMunicipalId)
        {
            var result = seccionService.GetAllSeccionesByDistritoMunicipalId(distritoMunicipalId);

            return Ok(result);
        }
    }
}
