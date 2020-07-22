using AutoMapper;
using CRD.Common.DTOs.DtoIn;
using CRD.Common.DTOs.DtoOut;
using CRD.Domain.Models;

namespace CRD.AplicationCore.Profiles
{
    public class ProvinciaProfile: Profile
    {
        public ProvinciaProfile() {
            CreateMap<Provincia, ProvinciaDtoOut>();
            CreateMap<ProvinciaDtoIn, Provincia>();
        }
    }
}
