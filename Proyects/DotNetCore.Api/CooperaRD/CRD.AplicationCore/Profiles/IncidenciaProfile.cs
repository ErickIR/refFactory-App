using AutoMapper;
using CRD.Common.DTOs.DtoOut;
using CRD.Domain.Models;

namespace CRD.AplicationCore.Profiles
{
    public class IncidenciaProfile : Profile
    {
        public IncidenciaProfile()
        {
            CreateMap<Incidencia,IncidenciaDtoOut>();
        }
    }
}
