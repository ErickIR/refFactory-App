using System;
using System.Collections.Generic;

namespace BackOfficeApp.Models
{
    public partial class TipoIncidencia
    {
        public TipoIncidencia()
        {
            Archivo = new HashSet<Archivo>();
            Incidencia = new HashSet<Incidencia>();
        }

        public int TipoIncidenciaId { get; set; }
        public string Descripccion { get; set; }

        public virtual ICollection<Archivo> Archivo { get; set; }
        public virtual ICollection<Incidencia> Incidencia { get; set; }
    }
}
