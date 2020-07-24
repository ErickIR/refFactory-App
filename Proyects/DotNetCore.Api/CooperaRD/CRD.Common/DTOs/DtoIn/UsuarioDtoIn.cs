
namespace CRD.Common.DTOs.DtoIn
{
    public class UsuarioDtoIn
    {
        public int TipoUsuarioId { get; set; }
        public int BarrioId { get; set; }
        public int TipoDocumentoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public byte[] FotoPerfil { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
    }
}
