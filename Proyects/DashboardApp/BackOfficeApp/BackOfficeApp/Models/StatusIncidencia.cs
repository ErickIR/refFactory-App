using System;
using System.Collections.Generic;

namespace BackOfficeApp.Models
{
    public partial class StatusIncidencia
    {
        public StatusIncidencia()
        {
            Incidencia = new HashSet<Incidencia>();
        }

        public int StatusIncidenciaId { get; set; }
        public string Descripccion { get; set; }

        public virtual ICollection<Incidencia> Incidencia { get; set; }
    }
}
