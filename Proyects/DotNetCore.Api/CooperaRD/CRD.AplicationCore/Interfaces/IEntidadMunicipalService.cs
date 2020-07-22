using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface IEntidadMunicipalService
    {
        ServiceResult<IEnumerable<EntidadMunicipalDtoOut>> GetAllEntidadesMunicipales();
        ServiceResult<EntidadMunicipalDtoOut> GetEntidadMunicipalByEntidadMunicipalId(int entidadMunicipalId);
        ServiceResult<IEnumerable<EntidadMunicipalDtoOut>> GetAllEntidadesMunicipalesByMunicipioId(int municipioId);
    }
}
