using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface IIncidenciaUsuarioService
    {
        ServiceResult<IEnumerable<IncidenciaUsuarioDtoOut>> GetAllIncidenciasUsuarios();
        ServiceResult<IncidenciaUsuarioDtoOut> GetIncidenciaUsuarioByIncidenciaUsuarioId(int incidenciaUsuarioId);
        ServiceResult<IEnumerable<IncidenciaUsuarioDtoOut>> GetAllIncidenciasUsuariosByIncidenciaId(int incidenciaId);
    }
}
