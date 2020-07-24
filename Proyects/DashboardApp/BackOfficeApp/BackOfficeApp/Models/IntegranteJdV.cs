using System;
using System.Collections.Generic;

namespace BackOfficeApp.Models
{
    public partial class IntegranteJdV
    {
        public int IntegranteId { get; set; }
        public int UsuarioId { get; set; }
        public int JuntaDeVecinosId { get; set; }
        public int RolId { get; set; }

        public virtual JuntaDeVecinos JuntaDeVecinos { get; set; }
        public virtual Rol Rol { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
