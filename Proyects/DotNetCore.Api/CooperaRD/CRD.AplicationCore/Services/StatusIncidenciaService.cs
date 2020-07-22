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
    public class StatusIncidenciaService: IStatusIncidenciaService
    {
        //Clase e interfaz de validacion , interfaz de esta clase, DTOs,  mapper, mensajes constantes, dependecy intejection en startup
        readonly IMasterRepository masterRepository;
        readonly IStatusIncidenciaValidationService statusIncidenciaValidationService;
        readonly IMapper mapper;

        public StatusIncidenciaService(IMasterRepository masterRepository, IStatusIncidenciaValidationService statusIncidenciaValidationService, IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.statusIncidenciaValidationService = statusIncidenciaValidationService;
            this.mapper = mapper;
        }

        public ServiceResult<IEnumerable<StatusIncidenciaDtoOut>> GetAllStatusIncidencias()
        {
            try
            {
                var listStatusIncidencia = masterRepository.StatusIncidencia.GetAll();

                var listStatusIncidenciaDto = new List<StatusIncidenciaDtoOut>();

                foreach (var statusIncidencia in listStatusIncidencia)
                {
                    var statusIncidenciaDto = mapper.Map<StatusIncidenciaDtoOut>(statusIncidencia);
                    listStatusIncidenciaDto.Add(statusIncidenciaDto);
                }

                return ServiceResult<IEnumerable<StatusIncidenciaDtoOut>>.ResultOk(listStatusIncidenciaDto);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<StatusIncidenciaDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<StatusIncidenciaDtoOut> GetStatusIncidenciaByStatusIncidenciaId(int statusIncidenciaId)
        {
            try
            {
                if (!statusIncidenciaValidationService.IsExistingStatusIncidenciaId(statusIncidenciaId))
                    throw new ValidationException(StatusIncidenciaMessageConstants.NotExistingStatusIncidenciaId);

                var statusIncidencia = masterRepository.StatusIncidencia.FindByCondition(s => 
                    s.StatusIncidenciaId == statusIncidenciaId).FirstOrDefault();

                var statusIncidenciaDto = mapper.Map<StatusIncidenciaDtoOut>(statusIncidencia);

                return ServiceResult<StatusIncidenciaDtoOut>.ResultOk(statusIncidenciaDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<StatusIncidenciaDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<StatusIncidenciaDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
    }
}
