using CRD.Common.DTOs.DtoIn;
using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface IIncidenciaService
    {
        ServiceResult<bool> CreateIncidencia(IncidenciaDtoIn incidenciaDto);
        ServiceResult<IEnumerable<IncidenciaDtoOut>> GetAllIncidencias();
        ServiceResult<IncidenciaDtoOut> GetIncidenciaByIncidenciaId(int incidenciaId);
        ServiceResult<IEnumerable<IncidenciaDtoOut>> GetAllIncidenciasByBarrioId(int barrioId);
        ServiceResult<IEnumerable<IncidenciaDtoOut>> GetAllIncidenciasByBarrioIdAndStatusIncidenciaId(int barrioId, int statusIncidenciaId);
        ServiceResult<IEnumerable<IncidenciaDtoOut>> GetAllIncidenciasByBarrioIdAndTipoIncidenciaId(int barrioId, int tipoIncidenciaId);
        ServiceResult<IEnumerable<IncidenciaDtoOut>> GetAllIncidenciasByUsuarioId(int usuarioId);

    }
}
