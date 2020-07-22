using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRD.AplicationCore.Interfaces;
using CRD.Common.DTOs.DtoIn;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        readonly IProvinciaService provinciaService;

        public ProvinciaController(IProvinciaService provinciaService)
        {
            this.provinciaService = provinciaService;
        }

        [HttpPost]
        public IActionResult CreateProvincia(ProvinciaDtoIn provinciaDto)
        {
            var result = provinciaService.CreateProvincia(provinciaDto);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllProvincias()
        {
            var result = provinciaService.GetAllProvincias();

            return Ok(result);
        }

        [HttpGet("{provinciaId}")]
        public IActionResult GetProvinciaByProvinciaId(int provinciaId)
        {
            var result = provinciaService.GetProvinciaByProvinciaId(provinciaId);

            return Ok(result);
        }

        [HttpPut("{provinciaId}")]
        public IActionResult UpdateProvincia(int provinciaId,[FromBody] ProvinciaDtoIn provinciaDto)
        {
            var result = provinciaService.UpdateProvincia(provinciaId, provinciaDto);

            return Ok(result);
        }

        [HttpDelete("{provinciaId}")]
        public IActionResult UpdateProvincia(int provinciaId)
        {
            var result = provinciaService.DeleteProvincia(provinciaId);

            return Ok(result);
        }

    }
}
