using System.Collections.Generic;

namespace CRD.Domain.Models
{
    public partial class Region
    {
        public Region()
        {
            Provincia = new HashSet<Provincia>();
        }

        public int RegionId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Provincia> Provincia { get; set; }
    }
}
