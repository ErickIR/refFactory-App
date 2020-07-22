using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using CRD.InfraData.Context;

namespace CRD.InfraData.Repositories
{
    public class IncidenciaUsuarioRepository : BaseRepository<IncidenciaUsuario> , IIncidenciaUsuarioRepository
    {
        public IncidenciaUsuarioRepository(CooperaDBContext context) : base(context)
        {
        }
    }
}
