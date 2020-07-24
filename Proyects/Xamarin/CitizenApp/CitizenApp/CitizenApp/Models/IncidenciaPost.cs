using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Models
{
    public class IncidenciaPost
    {
        public int EmpleadoId { get; set; }
        public int UsuarioId { get; set; }
        public int StatusId { get; set; }
        public int TipoId { get; set; }
        public int BarrioId { get; set; }
        public string Titulo { get; set; }
        public string Descripccion { get; set; }
        public byte[] Imagen { get; set; }
    }
}
