using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRD.AplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        readonly ITipoUsuarioService tipoUsuarioService;

        public TipoUsuarioController(ITipoUsuarioService tipoUsuarioService)
        {
            this.tipoUsuarioService = tipoUsuarioService;
        }

        [HttpGet]
        public IActionResult GetAllTiposUsuario()
        {
            var result = tipoUsuarioService.GetAllTiposUsuario();

            return Ok(result);
        }

        [HttpGet("{tipoUsuarioId}")]
        public IActionResult GetAllTiposUsuario(int tipoUsuarioId)
        {
            var result = tipoUsuarioService.GetTipoUsuarioByTipoUsuarioId(tipoUsuarioId);

            return Ok(result);
        }
    }
}
