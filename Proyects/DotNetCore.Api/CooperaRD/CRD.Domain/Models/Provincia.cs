﻿using System.Collections.Generic;

namespace CRD.Domain.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Municipio = new HashSet<Municipio>();
        }

        public int ProvinciaId { get; set; }
        public int RegionId { get; set; }
        public string Nombre { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Municipio> Municipio { get; set; }
    }
}
