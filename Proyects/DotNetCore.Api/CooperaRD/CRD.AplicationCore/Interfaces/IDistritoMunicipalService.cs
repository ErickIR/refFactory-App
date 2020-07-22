using CRD.Common.DTOs.DtoIn;
using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface IDistritoMunicipalService
    {
        ServiceResult<int> CreateDistritoMunicipal(DistritoMunicipalDtoIn distritoMunicipalDto);
        ServiceResult<IEnumerable<DistritoMunicipalDtoOut>> GetAllDistritosMunicipales();
        ServiceResult<DistritoMunicipalDtoOut> GetDistritoMunicipalByDistritoMunicipalId(int distritoMunicipalId);
        ServiceResult<IEnumerable<DistritoMunicipalDtoOut>> GetAllDistritosMunicipalesByMunicipioId(int municipioId);
    }
}
