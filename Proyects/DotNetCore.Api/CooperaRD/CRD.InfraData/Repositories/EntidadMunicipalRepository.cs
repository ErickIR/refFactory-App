using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using CRD.InfraData.Context;

namespace CRD.InfraData.Repositories
{
    public class EntidadMunicipalRepository : BaseRepository<EntidadMunicipal> , IEntidadMunicipalRepository
    {
        public EntidadMunicipalRepository(CooperaDBContext context) : base(context)
        {
        }
    }
}
