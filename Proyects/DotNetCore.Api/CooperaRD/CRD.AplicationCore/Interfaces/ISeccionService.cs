using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface ISeccionService
    {
        ServiceResult<IEnumerable<SeccionDtoOut>> GetAllSecciones();
        ServiceResult<SeccionDtoOut> GetSeccionBySeccionId(int seccionId);
        ServiceResult<IEnumerable<SeccionDtoOut>> GetAllSeccionesByDistritoMunicipalId(int distritoMunicipalId);
    }
}
