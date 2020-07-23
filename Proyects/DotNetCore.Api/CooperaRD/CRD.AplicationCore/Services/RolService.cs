using AutoMapper;
using CRD.AplicationCore.Constants;
using CRD.AplicationCore.Interfaces;
using CRD.AplicationCore.Interfaces.Validations;
using CRD.Common.DTOs.DtoOut;
using CRD.Common.Enums;
using CRD.Common.Models;
using CRD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CRD.AplicationCore.Services
{
    public class RolService: IRolService
    {
        //Clase e interfaz de validacion , interfaz de esta clase, DTOs,  mapper, mensajes constantes, dependecy intejection en startup
        readonly IMasterRepository masterRepository;
        readonly IRolValidationService rolValidationService;
        readonly IMapper mapper;

        public RolService(IMasterRepository masterRepository, IRolValidationService rolValidationService, IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.rolValidationService = rolValidationService;
            this.mapper = mapper;
        }

        public ServiceResult<IEnumerable<RolDtoOut>> GetAllRoles()
        {
            try
            {
                var listRoles = masterRepository.Rol.GetAll();

                var listRolesDto = new List<RolDtoOut>();

                foreach (var rol in listRoles)
                {
                    var rolDto = mapper.Map<RolDtoOut>(rol);
                    listRolesDto.Add(rolDto);
                }
                return ServiceResult<IEnumerable<RolDtoOut>>.ResultOk(listRolesDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IEnumerable<RolDtoOut>>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<RolDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<RolDtoOut> GetRolByRolId(int rolId)
        {
            try
            {
                if (!rolValidationService.IsExistingRolId(rolId))
                    throw new ValidationException(RolMessageConstants.NotExistingRolId);

                var rol = masterRepository.Rol.FindByCondition(r => 
                    r.RolId == rolId).FirstOrDefault();

                var rolDto = mapper.Map<RolDtoOut>(rol);

                return ServiceResult<RolDtoOut>.ResultOk(rolDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<RolDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<RolDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
    }
}
