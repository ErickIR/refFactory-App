﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Models
{
    public class Municipio
    {
        public int MunicipioId { get; set; }
        public int ProvinciaId { get; set; }
        public string Nombre { get; set; }
    }
}
