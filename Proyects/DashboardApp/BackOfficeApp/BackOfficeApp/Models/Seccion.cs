using System;
using System.Collections.Generic;

namespace BackOfficeApp.Models
{
    public partial class Seccion
    {
        public Seccion()
        {
            Sector = new HashSet<Sector>();
        }

        public int SeccionId { get; set; }
        public int DistritoMunicipalId { get; set; }
        public string Nombre { get; set; }

        public virtual DistritoMunicipal DistritoMunicipal { get; set; }
        public virtual ICollection<Sector> Sector { get; set; }
    }
}
