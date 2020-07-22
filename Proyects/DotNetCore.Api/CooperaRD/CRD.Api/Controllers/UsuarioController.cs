﻿using System;
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
    public class UsuarioController : ControllerBase
    {
        readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult GetAllUsuarios()
        {
            var result = usuarioService.GetAllUsuarios();

            return Ok(result);
        }

        [HttpGet("{usuarioId}")]
        public IActionResult GetUsuarioByUsuarioId(int usuarioId)
        {
            var result = usuarioService.GetUsuarioByUsuarioId(usuarioId);

            return Ok(result);
        }
    }
}
