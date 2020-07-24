using System;
using System.Collections.Generic;

namespace BackOfficeApp.Models
{
    public partial class Archivo
    {
        public int ArchivoId { get; set; }
        public int ExtensionId { get; set; }
        public int IncidenciaId { get; set; }
        public int TipoId { get; set; }
        public string Nombre { get; set; }
        public byte[] Fichero { get; set; }
        public DateTime? FechaCreado { get; set; }

        public virtual ExtensionArchivo Extension { get; set; }
        public virtual Incidencia Incidencia { get; set; }
        public virtual TipoIncidencia Tipo { get; set; }
    }
}
