﻿using AutoMapper;
using CRD.Common.DTOs.DtoIn;
using CRD.Common.DTOs.DtoOut;
using CRD.Domain.Models;

namespace CRD.AplicationCore.Profiles
{
    public class IncidenciaUsuarioProfile: Profile
    {
        public IncidenciaUsuarioProfile()
        {
            CreateMap<IncidenciaUsuario, IncidenciaUsuarioDtoOut>();
            CreateMap<IncidenciaUsuarioDtoIn, IncidenciaUsuario>();
        }
    }
}
