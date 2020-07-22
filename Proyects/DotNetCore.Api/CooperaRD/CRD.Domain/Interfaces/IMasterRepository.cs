
namespace CRD.Domain.Interfaces
{
    public interface IMasterRepository
    {
        IBarrioRepository Barrio { get; }
        ICargoRepository Cargo { get; }
        IDistritoMunicipalRepository DistritoMunicipal { get; }
        IEntidadMunicipalRepository EntidadMunicipal { get; }
        IIncidenciaRepository Incidencia { get; }
        IIncidenciaUsuarioRepository IncidenciaUsuario { get; }
        IIntegranteJdVRepository IntegranteJdV { get; }
        IJuntaDeVecinosRepository JuntaDeVecinos { get; }
        IMunicipioRepository Municipio { get; }
        IProvinciaRepository Provincia { get; }
        IRegionRepository Region { get; }
        IRolRepository Rol { get; }
        ISeccionRepository Seccion { get; }
        ISectorRepository Sector { get; }
        IStatusIncidenciaRepository StatusIncidencia { get; }
        ITipoDocumentoRepository TipoDocumento { get; }
        ITipoIncidenciaRepository TipoIncidencia { get; }
        ITipoUsuarioRepository TipoUsuario { get; }
        IUsuarioRepository Usuario { get; }
        void Save();
    }
}
