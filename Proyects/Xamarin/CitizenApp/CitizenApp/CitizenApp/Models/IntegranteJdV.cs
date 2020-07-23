using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Models
{
    public class IntegranteJdV
    {
        public int IntegranteId { get; set; }
        public Usuario usuario { get; set; }
        public int UsuarioId { get; set; }
        public int JuntaDeVecinosId { get; set; }
        public Rol rol { get; set; }
        public int RoldId { get; set; }
    }
}
