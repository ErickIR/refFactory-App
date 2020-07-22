
namespace CRD.Common.DTOs.DtoOut
{
    public class EntidadMunicipalDtoOut
    {
        public int EntidadMunicipalId { get; set; }
        public CargoDtoOut Cargo { get; set; }
        public TipoDocumentoDtoOut TipoDocumento { get; set; }
        public MunicipioDtoOut Municipio { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public byte[] FotoPerfil { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
    }
}
