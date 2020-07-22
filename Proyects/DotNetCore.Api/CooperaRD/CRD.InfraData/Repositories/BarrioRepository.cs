using CRD.Domain.Models;
using CRD.InfraData.Context;
using CRD.Domain.Interfaces;

namespace CRD.InfraData.Repositories
{
    public class BarrioRepository : BaseRepository<Barrio> , IBarrioRepository
    {
        public BarrioRepository(CooperaDBContext context) : base(context)
        {
        }
    }
}
