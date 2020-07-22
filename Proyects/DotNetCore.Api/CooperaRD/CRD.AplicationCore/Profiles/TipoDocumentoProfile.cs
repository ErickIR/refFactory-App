using AutoMapper;
using CRD.Common.DTOs.DtoOut;
using CRD.Domain.Models;

namespace CRD.AplicationCore.Profiles
{
    public class TipoDocumentoProfile: Profile
    {
        public TipoDocumentoProfile()
        {
            CreateMap<TipoDocumento, TipoDocumentoDtoOut>();
        }
    }
}
