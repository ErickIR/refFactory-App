using AutoMapper;
using CRD.Common.DTOs.DtoOut;
using CRD.Domain.Models;

namespace CRD.AplicationCore.Profiles
{
    class CargoProfile: Profile
    {
        public CargoProfile()
        {
            CreateMap<Cargo, CargoDtoOut>();
        }
    }
}
