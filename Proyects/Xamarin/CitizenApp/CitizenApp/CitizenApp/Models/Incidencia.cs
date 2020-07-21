using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitizenApp.Models
{
    public class Incidencia
    {
        public int IncidenciaId { get; set; }
        public int EmpleadoId { get; set; }
        public int UsuarioId { get; set; }
        public int StatusId { get; set; }
        public int TipoIncidenciaId { get; set; }
        public int BarrioId { get; set; }
        public byte[] Imagen { get; set; }
        public string TituloImagen { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public Usuario Empleado { get; set; }
        public Usuario Usuario { get; set; }
        public StatusIncidencia Status { get; set; }
        public TipoIncidencia TipoIncidencia { get; set; }
        public Barrio Barrio { get; set; }

        public IEnumerable<IncidenciaUsuario> Apoyos { get; set; }
    }
}
