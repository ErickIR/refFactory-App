using System;
using System.Collections.Generic;

namespace BackOfficeApp.Models
{
    public partial class Sector
    {
        public Sector()
        {
            Barrio = new HashSet<Barrio>();
        }

        public int SectorId { get; set; }
        public int SeccionId { get; set; }
        public string Nombre { get; set; }

        public virtual Seccion Seccion { get; set; }
        public virtual ICollection<Barrio> Barrio { get; set; }
    }
}
