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
    public class IncidenciaController : ControllerBase
    {
        readonly IIncidenciaService incidenciaService;

        public IncidenciaController(IIncidenciaService incidenciaService)
        {
            this.incidenciaService = incidenciaService;
        }

        [HttpGet]
        public IActionResult GetAllIncidencias()
        {
            var result = incidenciaService.GetAllIncidencias();

            return Ok(result);
        }

        [HttpGet("{incidenciaId}")]
        public IActionResult GetIncidenciaByIncidenciaId(int incidenciaId)
        {
            var result = incidenciaService.GetIncidenciaByIncidenciaId(incidenciaId);

            return Ok(result);
        }

        [HttpGet("barrio/{barrioId}")]
        public IActionResult GetAllIncidenciasByBarrioId(int barrioId)
        {
            var result = incidenciaService.GetAllIncidenciasByBarrioId(barrioId);

            return Ok(result);
        }

        [HttpGet("barrio/{barrioId}/status-incidencia/{statusIncidenciaId}")]
        public IActionResult GetAllIncidenciasByBarrioIdAndStatusIncidenciaId(int barrioId,int statusIncidenciaId)
        {
            var result = incidenciaService.GetAllIncidenciasByBarrioIdAndStatusIncidenciaId(barrioId,statusIncidenciaId);

            return Ok(result);
        }

        [HttpGet("barrio/{barrioId}/tipo-incidencia/{tipoIncidenciaId}")]
        public IActionResult GetAllIncidenciasByBarrioIdAndTipoIncidenciaId(int barrioId, int tipoIncidenciaId)
        {
            var result = incidenciaService.GetAllIncidenciasByBarrioIdAndTipoIncidenciaId(barrioId, tipoIncidenciaId);

            return Ok(result);
        }

        [HttpGet("usuario/{usuarioId}")]
        public IActionResult GetAllIncidenciasByUsuarioId(int usuarioId)
        {
            var result = incidenciaService.GetAllIncidenciasByUsuarioId(usuarioId);

            return Ok(result);
        }

    }
}
