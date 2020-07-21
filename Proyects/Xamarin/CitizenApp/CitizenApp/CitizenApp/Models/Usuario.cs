using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public int TipoUsuarioId { get; set; }
        public int BarrioId { get; set; }
        public int TipoDocumentoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }

        public string NombreCompleto
        {
            get => $"{Nombres} {Apellidos}";
        }
    }
}
