using AutoMapper;
using CRD.Common.DTOs.DtoOut;
using CRD.Domain.Models;

namespace CRD.AplicationCore.Profiles
{
    public class EntidadMunicipalProfile : Profile
    {
        public EntidadMunicipalProfile()
        {
            CreateMap<EntidadMunicipal, EntidadMunicipalDtoOut>();
        }
    }
}
