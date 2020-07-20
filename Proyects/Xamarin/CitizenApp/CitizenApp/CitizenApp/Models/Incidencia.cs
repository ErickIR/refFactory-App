using System;
using System.Collections.Generic;
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
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
    }
}
