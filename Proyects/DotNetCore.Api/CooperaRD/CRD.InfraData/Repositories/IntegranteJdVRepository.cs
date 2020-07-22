using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using CRD.InfraData.Context;

namespace CRD.InfraData.Repositories
{
    public class IntegranteJdVRepository : BaseRepository<IntegranteJdV>, IIntegranteJdVRepository
    {
        public IntegranteJdVRepository(CooperaDBContext context) : base(context)
        {
        }
    }
}
