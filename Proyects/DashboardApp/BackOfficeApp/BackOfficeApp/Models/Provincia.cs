﻿using System;
using System.Collections.Generic;

namespace BackOfficeApp.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Municipio = new HashSet<Municipio>();
        }

        public int ProvinciaId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Municipio> Municipio { get; set; }
    }
}
