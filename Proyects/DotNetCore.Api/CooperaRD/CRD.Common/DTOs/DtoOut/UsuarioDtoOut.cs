using System;
using System.Collections.Generic;
using System.Text;

namespace CRD.Common.DTOs.DtoOut
{
    public class UsuarioDtoOut
    {
        public int UsuarioId { get; set; }
        public TipoUsuarioDtoOut TipoUsuario { get; set; }
        public BarrioDtoOut Barrio { get; set; }
        public TipoDocumentoDtoOut TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public byte[] FotoPerfil { get; set; }
        public string Email { get; set; }
    }
}
