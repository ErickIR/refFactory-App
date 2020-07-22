using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using CRD.InfraData.Context;

namespace CRD.InfraData.Repositories
{
    public class SeccionRepository : BaseRepository<Seccion>, ISeccionRepository
    {
        public SeccionRepository(CooperaDBContext context) : base(context)
        {
        }
    }
}
