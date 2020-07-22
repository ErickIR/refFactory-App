using CRD.AplicationCore.Interfaces;
using CRD.Common.DTOs.DtoIn;
using Microsoft.AspNetCore.Mvc;

namespace CRD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        readonly IMunicipioService municipioService;

        public MunicipioController(IMunicipioService municipioService)
        {
            this.municipioService = municipioService;
        }

        [HttpPost]
        public IActionResult CreateMunicipio(MunicipioDtoIn municipioDto)
        {
            var result = municipioService.CreateMunicipio(municipioDto);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetallMunicipios()
        {
            var result = municipioService.GetAllMunicipios();

            return Ok(result);
        }


        [HttpGet("{municipioId}")]
        public IActionResult GetallMunicipios(int municipioId)
        {
            var result = municipioService.GetMunicipioByMunicipioId(municipioId);

            return Ok(result);
        }

        [HttpGet("barrio/{barrioId}")]
        public IActionResult GetMunicipioByBarrioId(int barrioId)
        {
            var result = municipioService.GetMunicipioByBarrioId(barrioId);

            return Ok(result);
        }
        [HttpPut("{municipioId}")]

        public IActionResult UpdateMunicipio(int municipioId,[FromBody] MunicipioDtoIn municipioDto)
        {
            var result = municipioService.UpdateMunicipio(municipioId,municipioDto);

            return Ok(result);
        }

        [HttpDelete("{municipioId}")]

        public IActionResult DeleteMunicipio(int municipioId)
        {
            var result = municipioService.DeleteMunicipio(municipioId);

            return Ok(result);
        }

        
    }
}
