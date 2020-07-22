using AutoMapper;
using CRD.Common.DTOs.DtoOut;
using CRD.Domain.Models;

namespace CRD.AplicationCore.Profiles
{
    public class SectorProfile: Profile
    {
        public SectorProfile()
        {
            CreateMap<Sector, SectorDtoOut>();
        }
    }
}
