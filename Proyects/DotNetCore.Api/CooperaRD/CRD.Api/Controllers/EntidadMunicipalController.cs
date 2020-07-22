using CRD.AplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadMunicipalController : ControllerBase
    {
        readonly IEntidadMunicipalService entidadMunicipalService;

        public EntidadMunicipalController(IEntidadMunicipalService entidadMunicipalService)
        {
            this.entidadMunicipalService = entidadMunicipalService;
        }

        [HttpGet]
        public IActionResult GetAllEntidadesMunicipales()
        {
            var result = entidadMunicipalService.GetAllEntidadesMunicipales();

            return Ok(result);
        }

        [HttpGet("{entidadMunicipalId}")]
        public IActionResult GetEntidadMunicipalByEntidadMunicipalId(int entidadMunicipalId)
        {
            var result = entidadMunicipalService.GetEntidadMunicipalByEntidadMunicipalId(entidadMunicipalId);

            return Ok(result);
        }

        [HttpGet("municipio/{municipioId}")]
        public IActionResult GetAllEntidadesMunicipalesByMunicipioId(int municipioId)
        {
            var result = entidadMunicipalService.GetAllEntidadesMunicipalesByMunicipioId(municipioId);

            return Ok(result);
        }
    }
}
