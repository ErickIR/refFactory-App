using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class RolValidationService: IRolValidationService
    {
        readonly IMasterRepository masterRepository;
        public RolValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public bool IsExistingRolId(int rolId)
        {
            var isExisting = masterRepository.Rol.GetAll().Any(r =>
                r.RolId == rolId);

            return isExisting;
        }
    }
}
