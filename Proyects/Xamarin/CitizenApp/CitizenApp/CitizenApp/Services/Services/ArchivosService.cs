using CitizenApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CitizenApp.Services.Services
{
    public class ArchivosService
    {
        List<Archivo> Archivos;
        List<ExtensionArchivo> Extensiones;
        List<TipoArchivo> TiposArchivo;

        public ArchivosService()
        {
            Archivos = new List<Archivo>();
            Extensiones = new List<ExtensionArchivo>()
            {
                new ExtensionArchivo { ExtensionArchivoId = 1, Descripcion = "PDF"},
                new ExtensionArchivo { ExtensionArchivoId = 2, Descripcion = "JPEG"},
                new ExtensionArchivo { ExtensionArchivoId = 3, Descripcion = "PNG"}
            };
            TiposArchivo = new List<TipoArchivo>()
            {
                new TipoArchivo { TipoArchivoId = 1, Descripcion = "Imagen Incidencia"},
                new TipoArchivo { TipoArchivoId = 2, Descripcion = "Normativa Municipal"}
            };
        }

        public async Task<Archivo> ObtenerUltimaNormativa()
        {
            throw await Task.FromResult(new NotImplementedException());
        }

        public async Task<IEnumerable<Archivo>> ObtenerImagenesIncidencia(int incidenciaId)
        {
            var archivos = Archivos.FindAll(arc => arc.IncidenciaId == incidenciaId);

            return await Task.FromResult(archivos);
        }
    }
}
