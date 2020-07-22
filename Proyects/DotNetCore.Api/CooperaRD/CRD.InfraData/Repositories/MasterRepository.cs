using CRD.Domain.Interfaces;
using CRD.InfraData.Context;

namespace CRD.InfraData.Repositories
{
    public class MasterRepository : IMasterRepository
    {
        readonly CooperaDBContext context;
        private IBarrioRepository barrioRepository;
        private ICargoRepository cargoRepository;
        private IDistritoMunicipalRepository distritoMunicipalRepository;
        private IEntidadMunicipalRepository entidadMunicipalRepository;
        private IIncidenciaRepository incidenciaRepository;
        private IIncidenciaUsuarioRepository incidenciaUsuarioRepository;
        private IIntegranteJdVRepository integranteJdVRepository;
        private IJuntaDeVecinosRepository juntaDeVecinosRepository;
        private IMunicipioRepository municipioRepository;
        private IProvinciaRepository provinciaRepository;
        private IRegionRepository regionRepository;
        private IRolRepository rolRepository;
        private ISeccionRepository seccionRepository;
        private ISectorRepository sectorRepository;
        private IStatusIncidenciaRepository statusIncidenciaRepository;
        private ITipoDocumentoRepository tipoDocumentoRepository;
        private ITipoIncidenciaRepository tipoIncidenciaRepository;
        private ITipoUsuarioRepository tipoUsuarioRepository;
        private IUsuarioRepository usuarioRepository;

        public MasterRepository(CooperaDBContext context)
        {
            this.context = context;
        }

        public IBarrioRepository Barrio
        {
            get
            {
                if (barrioRepository == null)
                    barrioRepository = new BarrioRepository(context);

                return barrioRepository;
            }
        }

        public ICargoRepository Cargo
        {
            get
            {
                if (cargoRepository == null)
                    cargoRepository = new CargoRepository(context);

                return cargoRepository;
            }
        }

        public IDistritoMunicipalRepository DistritoMunicipal
        {
            get
            {
                if (distritoMunicipalRepository == null)
                    distritoMunicipalRepository = new DistritoMunicipalRepository(context);

                return distritoMunicipalRepository;
            }
        }

        public IEntidadMunicipalRepository EntidadMunicipal
        {
            get
            {
                if (entidadMunicipalRepository == null)
                    entidadMunicipalRepository = new EntidadMunicipalRepository(context);

                return entidadMunicipalRepository;
            }
        }

        public IIncidenciaRepository Incidencia
        {
            get
            {
                if (incidenciaRepository == null)
                    incidenciaRepository = new IncidenciaRepository(context);

                return incidenciaRepository;
            }
        }

        public IIncidenciaUsuarioRepository IncidenciaUsuario
        {
            get
            {
                if (incidenciaUsuarioRepository == null)
                    incidenciaUsuarioRepository = new IncidenciaUsuarioRepository(context);

                return incidenciaUsuarioRepository;
            }
        }

        public IIntegranteJdVRepository IntegranteJdV 
        {
            get
            {
                if (integranteJdVRepository == null)
                    integranteJdVRepository = new IntegranteJdVRepository(context);

                return integranteJdVRepository;
            }
        }

        public IJuntaDeVecinosRepository JuntaDeVecinos 
        {
            get
            {
                if (juntaDeVecinosRepository == null)
                    juntaDeVecinosRepository = new JuntaDeVecinosRepository(context);

                return juntaDeVecinosRepository; 
            }
        }

        public IMunicipioRepository Municipio
        {
            get
            {
                if (municipioRepository == null)
                    municipioRepository = new MunicipioRepository(context);

                return municipioRepository;
            }
        }

        public IProvinciaRepository Provincia 
        {
            get
            {
                if (provinciaRepository == null)
                    provinciaRepository = new ProvinciaRepository(context);

                return provinciaRepository;
            }
        }

        public IRegionRepository Region 
        {
            get
            {
                if (regionRepository == null)
                    regionRepository = new RegionRepository(context);

                return regionRepository;
            }
        }

        public IRolRepository Rol
        {
            get
            {
                if (rolRepository == null)
                    rolRepository = new RolRepository(context);

                return rolRepository;
            }
        }

        public ISeccionRepository Seccion
        {
            get
            {
                if (seccionRepository == null)
                    seccionRepository = new SeccionRepository(context);

                return seccionRepository;
            }
        } 

        public ISectorRepository Sector
        {
            get
            {
                if (sectorRepository == null)
                    sectorRepository = new SectorRepository(context);

                return sectorRepository;
            }
        }

        public IStatusIncidenciaRepository StatusIncidencia
        {
            get
            {
                if (statusIncidenciaRepository == null)
                    statusIncidenciaRepository = new StatusIncidenciaRepository(context);

                return statusIncidenciaRepository;
            }
        }

        public ITipoDocumentoRepository TipoDocumento
        {
            get
            {
                if (tipoDocumentoRepository == null)
                    tipoDocumentoRepository = new TipoDocumentoRepository(context);

                return tipoDocumentoRepository;
            }
        }

        public ITipoIncidenciaRepository TipoIncidencia
        {
            get
            {
                if (tipoIncidenciaRepository == null)
                    tipoIncidenciaRepository = new TipoIncidenciaRepository(context);

                return tipoIncidenciaRepository;
            }
        }

        public ITipoUsuarioRepository TipoUsuario
        {
            get
            {
                if (tipoUsuarioRepository == null)
                    tipoUsuarioRepository = new TipoUsuarioRepository(context);

                return tipoUsuarioRepository;
            }
        }

        public IUsuarioRepository Usuario
        {
            get
            {
                if (usuarioRepository == null)
                    usuarioRepository = new UsuarioRepository(context);

                return usuarioRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
