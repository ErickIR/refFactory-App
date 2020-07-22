using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using CRD.InfraData.Context;

namespace CRD.InfraData.Repositories
{
    public class TipoDocumentoRepository : BaseRepository<TipoDocumento>, ITipoDocumentoRepository
    {
        public TipoDocumentoRepository(CooperaDBContext context) : base(context)
        {
        }
    }
}
