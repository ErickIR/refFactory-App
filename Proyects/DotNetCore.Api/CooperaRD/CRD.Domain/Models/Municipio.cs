using System.Collections.Generic;

namespace CRD.Domain.Models
{
    public partial class Municipio
    {
        public Municipio()
        {
            DistritoMunicipal = new HashSet<DistritoMunicipal>();
            EntidadMunicipal = new HashSet<EntidadMunicipal>();
        }

        public int MunicipioId { get; set; }
        public int ProvinciaId { get; set; }
        public string Nombre { get; set; }

        public virtual Provincia Provincia { get; set; }
        public virtual ICollection<DistritoMunicipal> DistritoMunicipal { get; set; }
        public virtual ICollection<EntidadMunicipal> EntidadMunicipal { get; set; }
    }
}
