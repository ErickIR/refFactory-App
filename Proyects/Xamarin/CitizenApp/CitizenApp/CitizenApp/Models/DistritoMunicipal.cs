using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Models
{
    public class DistritoMunicipal
    {
        public int DistritoMunicipalId { get; set; }
        public int MunicipioId { get; set; }
        public string Nombre { get; set; }
    }
}
