using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface ITipoIncidenciaService
    {
        ServiceResult<IEnumerable<TipoIncidenciaDtoOut>> GetAllTiposIncidencias();
        ServiceResult<TipoIncidenciaDtoOut> GetTipoIncidenciaByTipoIncidenciaId(int tipoIncidenciaId);
    }
}
