
using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface IStatusIncidenciaService
    {
        ServiceResult<IEnumerable<StatusIncidenciaDtoOut>> GetAllStatusIncidencias();
        ServiceResult<StatusIncidenciaDtoOut> GetStatusIncidenciaByStatusIncidenciaId(int statusIncidenciaId);
    }
}
