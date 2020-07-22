using System.Collections.Generic;

namespace CRD.Domain.Models
{
    public partial class Cargo
    {
        public Cargo()
        {
            EntidadMunicipal = new HashSet<EntidadMunicipal>();
        }

        public int CargoId { get; set; }
        public string Descripccion { get; set; }

        public virtual ICollection<EntidadMunicipal> EntidadMunicipal { get; set; }
    }
}
