using CRD.AplicationCore.Interfaces;
using CRD.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CRD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        readonly IRegionService regionService;
        public RegionController(IRegionService regionService)
        {
            this.regionService = regionService;
        }

        [HttpPost]
        public IActionResult CreateRegion( string nombre)
        {
            var result = regionService.CreateRegion(nombre);

            return Ok(result);
        }

        [HttpGet]

        public IActionResult GetAllRegiones()
        {
            var result = regionService.GetAllRegiones();

            return Ok(result);
        }

        [HttpGet("{regionId}")]

        public IActionResult GetRegionByRegionId(int regionId)
        {
            var result = regionService.GetRegionByRegionId(regionId);

            return Ok(result);
        }

        [HttpPut("{regionId}")]
        public IActionResult UpdateRegion(int regionId,[FromBody] NombreDto nombreDto)
        {
            var result = regionService.UpdateRegion(regionId,nombreDto.Nombre);

            return Ok(result);
        }

        [HttpDelete("{regionId}")]
        public IActionResult DeleteRegion(int regionId)
        {
            var result = regionService.DeleteRegion(regionId);

            return Ok(result);
        }

    }
}
