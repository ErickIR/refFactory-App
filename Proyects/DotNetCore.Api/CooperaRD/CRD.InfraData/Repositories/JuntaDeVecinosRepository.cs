using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using CRD.InfraData.Context;

namespace CRD.InfraData.Repositories
{
    public class JuntaDeVecinosRepository : BaseRepository<JuntaDeVecinos>, IJuntaDeVecinosRepository
    {
        public JuntaDeVecinosRepository(CooperaDBContext context) : base(context)
        {
        }
    }
}
