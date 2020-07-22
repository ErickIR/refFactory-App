using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using CRD.InfraData.Context;

namespace CRD.InfraData.Repositories
{
    public class StatusIncidenciaRepository : BaseRepository<StatusIncidencia>, IStatusIncidenciaRepository
    {
        public StatusIncidenciaRepository(CooperaDBContext context) : base(context)
        {
        }
    }
}
