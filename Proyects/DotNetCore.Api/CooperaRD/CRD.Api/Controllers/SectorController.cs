using CRD.AplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        readonly ISectorService sectorService;

        public SectorController(ISectorService sectorService)
        {
            this.sectorService = sectorService;
        }

        [HttpGet]
        public IActionResult GetAllSectores() {

            var result = sectorService.GetAllSectores();

            return Ok(result);
        
        }

        [HttpGet("{sectorId}")]
        public IActionResult GetSectorBySectorId(int sectorId)
        {

            var result = sectorService.GetSectorBySectorId(sectorId);

            return Ok(result);

        }

        [HttpGet("seccion/{seccionId}")]
        public IActionResult GetAllSectoresBySeccionId(int seccionId)
        {

            var result = sectorService.GetAllSectoresBySeccionId(seccionId);

            return Ok(result);

        }
    }
}
