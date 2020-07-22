using CRD.AplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        readonly ICargoService cargoService;

        public CargoController(ICargoService cargoService)
        {
            this.cargoService = cargoService;
        }

        [HttpGet]
        public IActionResult GetAllCargos()
        {
            var result = cargoService.GetAllCargos();

            return Ok(result);
        }

        [HttpGet("{cargoId}")]
        public IActionResult GetCargoByCargoId(int cargoId)
        {
            var result = cargoService.GetCargoByCargoId(cargoId);

            return Ok(result);
        }
    }
}
