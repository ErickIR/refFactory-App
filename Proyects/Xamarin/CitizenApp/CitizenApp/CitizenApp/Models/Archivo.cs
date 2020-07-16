using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Models
{
    public class Archivo
    {
        public int ArchivoId { get; set; }
        public int ExtensionId { get; set; }
        public int IncidenciaId { get; set; }
        public int TipoId { get; set; }
        public string Nombre { get; set; }
        public byte[] Fichero { get; set; }
        public DateTime FechaCreado { get; set; }
    }
}
