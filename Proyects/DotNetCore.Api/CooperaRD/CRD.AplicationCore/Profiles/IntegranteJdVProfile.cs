using AutoMapper;
using CRD.Common.DTOs.DtoOut;
using CRD.Domain.Models;

namespace CRD.AplicationCore.Profiles
{
    public class IntegranteJdVProfile : Profile
    {
        public IntegranteJdVProfile()
        {
            CreateMap<IntegranteJdV,IntegranteJdVDtoOut>();
        }
    }
}
