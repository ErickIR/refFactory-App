

namespace CRD.Domain.Models
{
    public partial class IncidenciaUsuario
    {
        public int IncidenciaUsuarioId { get; set; }
        public int UsuarioId { get; set; }
        public int IncidenciaId { get; set; }

        public virtual Incidencia Incidencia { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
