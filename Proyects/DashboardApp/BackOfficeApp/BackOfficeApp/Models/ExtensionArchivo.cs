using System;
using System.Collections.Generic;

namespace BackOfficeApp.Models
{
    public partial class ExtensionArchivo
    {
        public ExtensionArchivo()
        {
            Archivo = new HashSet<Archivo>();
        }

        public int ExtensionArchivoId { get; set; }
        public string Descripccion { get; set; }

        public virtual ICollection<Archivo> Archivo { get; set; }
    }
}
