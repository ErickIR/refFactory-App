using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using CRD.InfraData.Context;

namespace CRD.InfraData.Repositories
{
    public class ProvinciaRepository : BaseRepository<Provincia>, IProvinciaRepository
    {
        public ProvinciaRepository(CooperaDBContext context) : base(context)
        {
        }
    }
}
