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
    public class JuntaDeVecinosController : ControllerBase
    {
        readonly IJuntaDeVecinosService juntaDeVecinosService;

        public JuntaDeVecinosController(IJuntaDeVecinosService juntaDeVecinosService)
        {
            this.juntaDeVecinosService = juntaDeVecinosService;
        }

        [HttpGet]
        public IActionResult GetAllJuntasDeVecinos()
        {
            var result = juntaDeVecinosService.GetAllJuntasDeVecinos();

            return Ok(result);
        }

        [HttpGet("{juntaDeVecinosId}")]
        public IActionResult GetAllJuntasDeVecinos(int juntaDeVecinosId)
        {
            var result = juntaDeVecinosService.GetJuntaDeVecinosByJuntaDeVecinosId(juntaDeVecinosId);

            return Ok(result);
        }

        [HttpGet("barrio/{barrioId}")]
        public IActionResult GetAllJuntasDeVecinosByBarrioId(int barrioId)
        {
            var result = juntaDeVecinosService.GetAllJuntasDeVecinosByBarrioId(barrioId);

            return Ok(result);
        }

        [HttpGet("distrito-municipal/{distritoMunicipalId}")]
        public IActionResult GetAllJuntasDeVecinosByDistritoMunicipalId(int distritoMunicipalId)
        {
            var result = juntaDeVecinosService.GetAllJuntasDeVecinosByDistritoMunicipalId(distritoMunicipalId);

            return Ok(result);
        }
    }
}
