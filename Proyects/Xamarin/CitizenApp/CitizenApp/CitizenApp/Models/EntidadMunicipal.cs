using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Models
{
    public class EntidadMunicipal
    {
        public int EntidadMunicipalId { get; set; }
        public int CargoId { get; set; }
        public int TipoDocumentoId { get; set; }
        public int MunicipioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
    }
}
