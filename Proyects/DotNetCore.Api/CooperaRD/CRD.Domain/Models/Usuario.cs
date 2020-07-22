using System.Collections.Generic;

namespace CRD.Domain.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            IncidenciaEmpleado = new HashSet<Incidencia>();
            IncidenciaUsuario = new HashSet<Incidencia>();
            IncidenciaUsuarioNavigation = new HashSet<IncidenciaUsuario>();
        }


        public int UsuarioId { get; set; }
        public int TipoUsuarioId { get; set; }
        public int BarrioId { get; set; }
        public int TipoDocumentoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public byte[] FotoPerfil { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }

        public virtual Barrio Barrio { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
        public virtual IntegranteJdV IntegranteJdV { get; set; }
        public virtual ICollection<Incidencia> IncidenciaEmpleado { get; set; }
        public virtual ICollection<Incidencia> IncidenciaUsuario { get; set; }
        public virtual ICollection<IncidenciaUsuario> IncidenciaUsuarioNavigation { get; set; }
    }
}
