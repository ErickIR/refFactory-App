using AutoMapper;
using CRD.Common.DTOs.DtoIn;
using CRD.Common.DTOs.DtoOut;
using CRD.Domain.Models;

namespace CRD.AplicationCore.Profiles
{
    public class DistritoMunicipalProfile: Profile
    {
        public DistritoMunicipalProfile()
        {
            CreateMap<DistritoMunicipalDtoIn, DistritoMunicipal>();
            CreateMap<DistritoMunicipal, DistritoMunicipalDtoOut>();
        }
    }
}
