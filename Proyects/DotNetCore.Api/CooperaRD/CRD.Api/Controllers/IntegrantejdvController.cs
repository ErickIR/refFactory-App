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
    public class IntegranteJdvController : ControllerBase
    {
        readonly IIntegranteJdVService integranteJdVService;

        public IntegranteJdvController(IIntegranteJdVService integranteJdVService)
        {
            this.integranteJdVService = integranteJdVService;
        }

        [HttpGet]
        public IActionResult GetAllIntegrantesJdV()
        {
            var result = integranteJdVService.GetAllIntegrantesJdV();

            return Ok(result);
        }


        [HttpGet("{integranteJdvId}")]
        public IActionResult GetAllIntegrantesJdV(int integranteJdvId)
        {
            var result = integranteJdVService.GetIntegranteJdVByIntegranteId(integranteJdvId);

            return Ok(result);
        }

        [HttpGet("junta-de-vecinos/{juntaDeVecinosId}")]
        public IActionResult GetAllIntegrantesJdVByJuntaDeVecinosId(int juntaDeVecinosId)
        {
            var result = integranteJdVService.GetAllIntegrantesJdVByJuntaDeVecinosId(juntaDeVecinosId);

            return Ok(result);
        }
    }
}
