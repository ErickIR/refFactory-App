using CRD.AplicationCore.Interfaces;
using CRD.Common.DTOs.DtoIn;
using Microsoft.AspNetCore.Mvc;

namespace CRD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidenciaUsuarioController : ControllerBase
    {
        readonly IIncidenciaUsuarioService incidenciaUsuarioService;

        public IncidenciaUsuarioController(IIncidenciaUsuarioService incidenciaUsuarioService)
        {
            this.incidenciaUsuarioService = incidenciaUsuarioService;
        }

        [HttpPost]
        public IActionResult CreateIncidenciaUsuario(IncidenciaUsuarioDtoIn incidenciaUsuarioDto)
        {
            var result = incidenciaUsuarioService.CreateIncidenciaUsuario(incidenciaUsuarioDto);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllIncidenciasUsuarios()
        {
            var result = incidenciaUsuarioService.GetAllIncidenciasUsuarios();

            return Ok(result);
        }

        [HttpGet("{incidenciaUsuarioId}")]
        public IActionResult GetIncidenciaUsuarioByIncidenciaUsuarioId(int incidenciaUsuarioId)
        {
            var result = incidenciaUsuarioService.GetIncidenciaUsuarioByIncidenciaUsuarioId(incidenciaUsuarioId);

            return Ok(result);
        }

        [HttpGet("incidencia/{incidenciaId}")]
        public IActionResult GetAllIncidenciasUsuariosByIncidenciaId(int incidenciaId)
        {
            var result = incidenciaUsuarioService.GetAllIncidenciasUsuariosByIncidenciaId(incidenciaId);

            return Ok(result);
        }
    }
}
