using System;
using System.Collections.Generic;

namespace BackOfficeApp.Models
{
    public partial class EntidadMunicipal
    {
        public int EntidadMunicipalId { get; set; }
        public int CargoId { get; set; }
        public int TipoDocumentoId { get; set; }
        public int MunicipioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }

        public virtual Cargo Cargo { get; set; }
        public virtual Municipio Municipio { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}
