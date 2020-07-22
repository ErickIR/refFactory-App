using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface ITipoDocumentoService
    {
        ServiceResult<IEnumerable<TipoDocumentoDtoOut>> GetAllTiposDocumento();
        ServiceResult<TipoDocumentoDtoOut> GetAllTipoDocumentoByTipoDocumentoId(int tipoDocumentoId);
    }
}
