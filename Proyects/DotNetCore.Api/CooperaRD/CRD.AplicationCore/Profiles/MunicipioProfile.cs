using AutoMapper;
using CRD.Common.DTOs.DtoIn;
using CRD.Common.DTOs.DtoOut;
using CRD.Domain.Models;

namespace CRD.AplicationCore.Profiles
{
    public class MunicipioProfile : Profile
    {
        public MunicipioProfile()
        {
            CreateMap<MunicipioDtoIn, Municipio>();
            CreateMap<Municipio, MunicipioDtoOut>();
        }
    }
}
