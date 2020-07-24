using System;
using System.Collections.Generic;

namespace BackOfficeApp.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int TipoUsuarioId { get; set; }
        public string Descripccion { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
