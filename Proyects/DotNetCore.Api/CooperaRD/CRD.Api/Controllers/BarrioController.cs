using CRD.AplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarrioController : ControllerBase
    {
        readonly IBarrioService barrioService;

        public BarrioController(IBarrioService barrioService)
        {
            this.barrioService = barrioService;
        }

        [HttpGet]
        public IActionResult GetAllBarrios()
        {
            var result = barrioService.GetAllBarrios();

            return Ok(result);
        }

        [HttpGet("{barrioId}")]
        public IActionResult GetBarrioByBarrioId(int barrioId)
        {
            var result = barrioService.GetBarrioByBarrioId(barrioId);

            return Ok(result);
        }

        [HttpGet("sector/{sectorId}")]
        public IActionResult GetAllBarriosBySectorId(int sectorId)
        {
            var result = barrioService.GetAllBarriosBySectorId(sectorId);

            return Ok(result);
        }
    }
}
