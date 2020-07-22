
using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface ITipoUsuarioService
    {
        ServiceResult<IEnumerable<TipoUsuarioDtoOut>> GetAllTiposUsuario();
        ServiceResult<TipoUsuarioDtoOut> GetTipoUsuarioByTipoUsuarioId(int tipoUsuarioId);
    }
}
