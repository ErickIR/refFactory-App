using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using CRD.InfraData.Context;

namespace CRD.InfraData.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(CooperaDBContext context) : base(context)
        {
        }
    }
}
