using System.Collections.Generic;

namespace CRD.Domain.Models
{
    public partial class DistritoMunicipal
    {
        public DistritoMunicipal()
        {
            Seccion = new HashSet<Seccion>();
        }

        public int DistritoMunicipalId { get; set; }
        public int MunicipioId { get; set; }
        public string Nombre { get; set; }

        public virtual Municipio Municipio { get; set; }
        public virtual ICollection<Seccion> Seccion { get; set; }
    }
}
