using CRD.Domain.Models;
using CRD.InfraData.Context;
using CRD.Domain.Interfaces;

namespace CRD.InfraData.Repositories
{
    public class CargoRepository : BaseRepository<Cargo> , ICargoRepository
    {
        public CargoRepository(CooperaDBContext context) : base(context)
        {
        }
    }
}
