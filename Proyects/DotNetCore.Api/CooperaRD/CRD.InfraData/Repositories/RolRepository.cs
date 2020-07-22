using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using CRD.InfraData.Context;

namespace CRD.InfraData.Repositories
{
    public class RolRepository : BaseRepository<Rol>, IRolRepository
    {
        public RolRepository(CooperaDBContext context) : base(context)
        {
        }
    }
}
