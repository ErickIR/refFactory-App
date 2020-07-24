using CRD.Common.DTOs.DtoIn;
using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface IUsuarioService
    {
        ServiceResult<IEnumerable<UsuarioDtoOut>> GetAllUsuarios();
        ServiceResult<UsuarioDtoOut> GetUsuarioByUsuarioId(int usuarioId);
        ServiceResult<bool> CreateUsuario(UsuarioDtoIn usuarioDto);
    }
}
