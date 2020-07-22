using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using CRD.InfraData.Context;

namespace CRD.InfraData.Repositories
{
    public class TipoIncidenciaRepository : BaseRepository<TipoIncidencia>, ITipoIncidenciaRepository
    {
        public TipoIncidenciaRepository(CooperaDBContext context) : base(context)
        {
        }
    }
}
