using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Models
{
    public class UsuarioDtoOut
    {
        public int UsuarioId { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public Barrio Barrio { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public byte[] FotoPerfil { get; set; }
        public string Email { get; set; }
    }
}
