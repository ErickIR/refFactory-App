using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using CRD.InfraData.Context;

namespace CRD.InfraData.Repositories
{
    public class DistritoMunicipalRepository : BaseRepository<DistritoMunicipal> , IDistritoMunicipalRepository
    {
        public DistritoMunicipalRepository(CooperaDBContext context) : base(context)
        {
        }
    }
}
