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
    public class TipoIncidenciaService : ITipoIncidenciaService
    {
        //Clase e interfaz de validacion , interfaz de esta clase, DTOs,  mapper, mensajes constantes, dependecy intejection en startup

        readonly IMasterRepository masterRepository;
        readonly ITipoIncidenciaValidationService tipoIncidenciaValidationService;
        readonly IMapper mapper;

        public TipoIncidenciaService(IMasterRepository masterRepository, ITipoIncidenciaValidationService tipoIncidenciaValidationService, IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.tipoIncidenciaValidationService = tipoIncidenciaValidationService;
            this.mapper = mapper;
        }

        public ServiceResult<IEnumerable<TipoIncidenciaDtoOut>> GetAllTiposIncidencias()
        {
            try
            {
                var listTiposIncidencia = masterRepository.TipoIncidencia.GetAll();

                var listTipoIncidenciasDto = new List<TipoIncidenciaDtoOut>();

                foreach (var tipoIncidencia in listTiposIncidencia)
                {
                    var tipoIncidenciaDto = mapper.Map<TipoIncidenciaDtoOut>(tipoIncidencia);
                    listTipoIncidenciasDto.Add(tipoIncidenciaDto);
                }

                return ServiceResult<IEnumerable<TipoIncidenciaDtoOut>>.ResultOk(listTipoIncidenciasDto);
            }
            
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<TipoIncidenciaDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<TipoIncidenciaDtoOut> GetTipoIncidenciaByTipoIncidenciaId(int tipoIncidenciaId)
        {
            try
            {
                if (!tipoIncidenciaValidationService.IsExistingTipoIncidenciaId(tipoIncidenciaId))
                    throw new ValidationException(TipoIncidenciaMessageConstants.NotExistingTipoIncidenciaId);

                var tipoIncidencia = masterRepository.TipoDocumento.FindByCondition(t =>
                    t.TipoDocumentoId == tipoIncidenciaId).FirstOrDefault();

                var tipoIncidenciaDto = mapper.Map<TipoIncidenciaDtoOut>(tipoIncidencia);

                return ServiceResult<TipoIncidenciaDtoOut>.ResultOk(tipoIncidenciaDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<TipoIncidenciaDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<TipoIncidenciaDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
        
    }
}
