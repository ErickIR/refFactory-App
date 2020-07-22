using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using CRD.InfraData.Context;

namespace CRD.InfraData.Repositories
{
    public class MunicipioRepository: BaseRepository<Municipio>, IMunicipioRepository
    {
        public MunicipioRepository(CooperaDBContext context) : base(context)
        {
        }
    }
}
