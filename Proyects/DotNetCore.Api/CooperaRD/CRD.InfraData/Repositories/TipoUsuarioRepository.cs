using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using CRD.InfraData.Context;

namespace CRD.InfraData.Repositories
{
    public class TipoUsuarioRepository : BaseRepository<TipoUsuario>, ITipoUsuarioRepository
    {
        public TipoUsuarioRepository(CooperaDBContext context) : base(context)
        {
        }
    }
}
