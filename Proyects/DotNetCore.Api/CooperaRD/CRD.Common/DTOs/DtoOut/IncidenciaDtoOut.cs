using System;

namespace CRD.Common.DTOs.DtoOut
{
    public class IncidenciaDtoOut
    {
        public int IncidenciaId { get; set; }
        public UsuarioDtoOut Empleado { get; set; }
        public UsuarioDtoOut Usuario { get; set; }
        public StatusIncidenciaDtoOut Status { get; set; }
        public TipoIncidenciaDtoOut Tipo { get; set; }
        public BarrioDtoOut Barrio { get; set; }
        public string Titulo { get; set; }
        public string Descripccion { get; set; }
        public byte[] Imagen { get; set; }
        public string Comentario { get; set; }
        public DateTime? FechaCreado { get; set; }
        public int Apoyos { get; set; }
    }
}
