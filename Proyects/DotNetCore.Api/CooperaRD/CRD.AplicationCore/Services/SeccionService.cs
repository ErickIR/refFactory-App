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
    public class SeccionService : ISeccionService
    {
        //Clase e interfaz de validacion , interfaz de esta clase,DTOs,   
        //mapper, mensajes constantes, dependecy intejection en startup
        readonly IMasterRepository masterRepository;
        readonly ISeccionValidationService seccionValidationService;
        readonly IDistritoMunicipalValidationService distritoMunicipalValidationService;
        readonly IMapper mapper;

        public SeccionService(IMasterRepository masterRepository, ISeccionValidationService seccionValidationService,
            IDistritoMunicipalValidationService distritoMunicipalValidationService, IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.seccionValidationService = seccionValidationService;
            this.distritoMunicipalValidationService = distritoMunicipalValidationService;
            this.mapper = mapper;
        }

        public ServiceResult<IEnumerable<SeccionDtoOut>> GetAllSecciones()
        {
            try
            {
                var listSecciones = masterRepository.Seccion.GetAll();

                var listSeccionesDto = new List<SeccionDtoOut>();

                foreach (var seccion in listSecciones)
                {
                    var seccionDto = mapper.Map<SeccionDtoOut>(seccion);
                    listSeccionesDto.Add(seccionDto);
                }

                return ServiceResult<IEnumerable<SeccionDtoOut>>.ResultOk(listSeccionesDto);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<SeccionDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
        public ServiceResult<SeccionDtoOut> GetSeccionBySeccionId(int seccionId)
        {
            try
            {
                if (!seccionValidationService.IsExistingSeccionId(seccionId))
                    throw new ValidationException(SeccionMessageConstants.NotExistingSeccionId);

                var seccion = masterRepository.Seccion.FindByCondition(s =>
                    s.SeccionId == seccionId).FirstOrDefault();

                var seccionDto = mapper.Map<SeccionDtoOut>(seccion);

                return ServiceResult<SeccionDtoOut>.ResultOk(seccionDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<SeccionDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<SeccionDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<IEnumerable<SeccionDtoOut>> GetAllSeccionesByDistritoMunicipalId(int distritoMunicipalId) 
        {
            try
            {
                if (!distritoMunicipalValidationService.IsExistingDistritoMunicipalId(distritoMunicipalId))
                    throw new ValidationException(DistritoMunicipalMessageConstants.NotExistingDistritoMunicipalId);

                var listSecciones = masterRepository.Seccion.FindByCondition(s =>
                    s.DistritoMunicipalId == distritoMunicipalId);

                if (listSecciones.Count() == 0)
                    throw new ValidationException(SeccionMessageConstants.NotExistingSeccionInDistritoMunicipal);

                var listSeccionesDto = new List<SeccionDtoOut>();

                foreach (var seccion in listSecciones)
                {
                    var seccionDto = mapper.Map<SeccionDtoOut>(seccion);
                    listSeccionesDto.Add(seccionDto);
                }

                return ServiceResult<IEnumerable<SeccionDtoOut>>.ResultOk(listSeccionesDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IEnumerable<SeccionDtoOut>>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<SeccionDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
    }
}
