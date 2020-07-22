using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using CRD.InfraData.Context;

namespace CRD.InfraData.Repositories
{
    public class IncidenciaRepository : BaseRepository<Incidencia> , IIncidenciaRepository
    {
        public IncidenciaRepository(CooperaDBContext context) : base(context)
        {
        }
    }
}
