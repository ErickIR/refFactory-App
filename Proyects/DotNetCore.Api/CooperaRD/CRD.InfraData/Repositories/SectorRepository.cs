using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using CRD.InfraData.Context;

namespace CRD.InfraData.Repositories
{
    public class SectorRepository : BaseRepository<Sector>, ISectorRepository
    {
        public SectorRepository(CooperaDBContext context) : base(context)
        {
        }
    }
}
