using System.Collections.Generic;

namespace CRD.Domain.Models
{
    public partial class TipoIncidencia
    {
        public TipoIncidencia()
        {
            Incidencia = new HashSet<Incidencia>();
        }

        public int TipoIncidenciaId { get; set; }
        public string Descripccion { get; set; }

        public virtual ICollection<Incidencia> Incidencia { get; set; }
    }
}
