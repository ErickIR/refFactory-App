using System;
using System.Collections.Generic;

namespace BackOfficeApp.Models
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            EntidadMunicipal = new HashSet<EntidadMunicipal>();
            Usuario = new HashSet<Usuario>();
        }

        public int TipoDocumentoId { get; set; }
        public string Descripccion { get; set; }

        public virtual ICollection<EntidadMunicipal> EntidadMunicipal { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
