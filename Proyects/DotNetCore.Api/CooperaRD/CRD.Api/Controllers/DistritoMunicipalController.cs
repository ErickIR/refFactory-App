using CRD.AplicationCore.Interfaces;
using CRD.Common.DTOs.DtoIn;
using Microsoft.AspNetCore.Mvc;

namespace CRD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistritoMunicipalController : ControllerBase
    {
        readonly IDistritoMunicipalService distritoMunicipalService;

        public DistritoMunicipalController(IDistritoMunicipalService distritoMunicipalService)
        {
            this.distritoMunicipalService = distritoMunicipalService;
        }

        [HttpPost]
        public IActionResult CreateDistritoMunicipal(DistritoMunicipalDtoIn distritoMunicipalDto)
        {
            var result = distritoMunicipalService.CreateDistritoMunicipal(distritoMunicipalDto);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllDistritoMunicipal()
        {
            var result = distritoMunicipalService.GetAllDistritosMunicipales();

            return Ok(result);
        }

        [HttpGet("{distritoMunicipalId}")]
        public IActionResult GetAllDistritoMunicipal(int distritoMunicipalId)
        {
            var result = distritoMunicipalService.GetDistritoMunicipalByDistritoMunicipalId(distritoMunicipalId);

            return Ok(result);
        }
        
        [HttpGet("municipio/{municipioId}")]
        public IActionResult GetAllDistritosMunicipalesByMunicipioId(int municipioId)
        {
            var result = distritoMunicipalService.GetAllDistritosMunicipalesByMunicipioId(municipioId);

            return Ok(result);
        }
    }
}
