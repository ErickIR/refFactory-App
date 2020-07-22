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
    public class TipoDocumentoService: ITipoDocumentoService
    {
        //Clase e interfaz de validacion , interfaz de esta clase, DTOs,  mapper, mensajes constantes, dependecy intejection en startup

        readonly IMasterRepository masterRepository;
        readonly ITipoDocumentoValidationService tipoDocumentoValidationService;
        readonly IMapper mapper;

        public TipoDocumentoService(IMasterRepository masterRepository, ITipoDocumentoValidationService tipoDocumentoValidationService, IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.tipoDocumentoValidationService = tipoDocumentoValidationService;
            this.mapper = mapper;
        }

        public ServiceResult<IEnumerable<TipoDocumentoDtoOut>> GetAllTiposDocumento()
        {
            try
            {
                var listTiposDocumento = masterRepository.TipoDocumento.GetAll();

                var listTiposDocumentoDto = new List<TipoDocumentoDtoOut>();

                foreach (var tipoDocumento in listTiposDocumento)
                {
                    var tipoDocumentoDto = mapper.Map<TipoDocumentoDtoOut>(tipoDocumento);
                    listTiposDocumentoDto.Add(tipoDocumentoDto);
                }

                return ServiceResult<IEnumerable<TipoDocumentoDtoOut>>.ResultOk(listTiposDocumentoDto);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<TipoDocumentoDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<TipoDocumentoDtoOut> GetAllTipoDocumentoByTipoDocumentoId(int tipoDocumentoId)
        {
            try
            {
                if (!tipoDocumentoValidationService.IsExistingTipoDocumentoId(tipoDocumentoId))
                    throw new ValidationException(TipoDocumentoMessageConstants.NotExistingTipoDocumentoId);

                var tipoDocumento = masterRepository.TipoDocumento.FindByCondition(t =>
                    t.TipoDocumentoId == tipoDocumentoId).FirstOrDefault();

                var tipoDocumentoDto = mapper.Map<TipoDocumentoDtoOut>(tipoDocumento);

                return ServiceResult<TipoDocumentoDtoOut>.ResultOk(tipoDocumentoDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<TipoDocumentoDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<TipoDocumentoDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
    }
}
