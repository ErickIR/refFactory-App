
namespace CRD.Common.DTOs.DtoIn
{
    public class IncidenciaDtoIn
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
