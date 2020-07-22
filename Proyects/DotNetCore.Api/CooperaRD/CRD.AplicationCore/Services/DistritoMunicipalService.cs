using AutoMapper;
using CRD.AplicationCore.Constants;
using CRD.AplicationCore.Interfaces;
using CRD.AplicationCore.Interfaces.Validations;
using CRD.Common.DTOs.DtoIn;
using CRD.Common.DTOs.DtoOut;
using CRD.Common.Enums;
using CRD.Common.Models;
using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CRD.AplicationCore.Services
{
    public class DistritoMunicipalService: IDistritoMunicipalService
    {
        //Clase e interfaz de validacion , interfaz de esta clase, DTOs,  mapper, mensajes constantes, dependecy intejection en startup

        readonly IMasterRepository masterRepository;
        readonly IGeneralValidationService generalValidationService;
        readonly IDistritoMunicipalValidationService distritoMunicipalValidationService;
        readonly IMunicipioValidationService municipioValidationService;
        readonly IMapper mapper;

        public DistritoMunicipalService(IMasterRepository masterRepository, IGeneralValidationService generalValidationService,
            IDistritoMunicipalValidationService distritoMunicipalValidationService, 
            IMunicipioValidationService municipioValidationService, IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.generalValidationService = generalValidationService;
            this.distritoMunicipalValidationService = distritoMunicipalValidationService;
            this.municipioValidationService = municipioValidationService;
            this.mapper = mapper;
        }

        public ServiceResult<int> CreateDistritoMunicipal(DistritoMunicipalDtoIn distritoMunicipalDto)
        {
            try
            {
                if (generalValidationService.IsEmptyText(distritoMunicipalDto.Nombre))
                    throw new ValidationException(DistritoMunicipalMessageConstants.EmptyDistritoMunicipalName);

                if (distritoMunicipalValidationService.IsExistingDistritoMunicipalName(distritoMunicipalDto.Nombre))
                    throw new ValidationException(DistritoMunicipalMessageConstants.ExistingDistritoMunicipalName);

                if (!municipioValidationService.IsExistingMunicipioId(distritoMunicipalDto.MunicipioId))
                    throw new ValidationException(MunicipioMessageConstants.NotExistingMunicipioId);

                distritoMunicipalDto.Nombre = generalValidationService.GetRewrittenTextFirstCapitalLetter(
                    distritoMunicipalDto.Nombre);

                var distritoMunicipal = mapper.Map<DistritoMunicipal>(distritoMunicipalDto);

                masterRepository.DistritoMunicipal.Create(distritoMunicipal);
                masterRepository.Save();

                distritoMunicipal = masterRepository.DistritoMunicipal.FindByCondition(d =>
                    d.Nombre == distritoMunicipalDto.Nombre).FirstOrDefault();
                return ServiceResult<int>.ResultOk(distritoMunicipal.DistritoMunicipalId);
            }
            catch (ValidationException e)
            {
                return ServiceResult<int>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<int>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<IEnumerable<DistritoMunicipalDtoOut>> GetAllDistritosMunicipales()
        {
            try
            {
                var listDistritosMunicipales = masterRepository.DistritoMunicipal.GetAll();

                var listDistritosMunicipalesDto = new List<DistritoMunicipalDtoOut>();

                foreach (var distritoMunicipal in listDistritosMunicipales)
                {
                    var distritoMunicipalDto = mapper.Map<DistritoMunicipalDtoOut>(distritoMunicipal);
                    listDistritosMunicipalesDto.Add(distritoMunicipalDto);
                }
                return ServiceResult<IEnumerable<DistritoMunicipalDtoOut>>.ResultOk(listDistritosMunicipalesDto);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<DistritoMunicipalDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<DistritoMunicipalDtoOut> GetDistritoMunicipalByDistritoMunicipalId(int distritoMunicipalId)
        {
            try
            {
                if (!distritoMunicipalValidationService.IsExistingDistritoMunicipalId(distritoMunicipalId))
                    throw new ValidationException(DistritoMunicipalMessageConstants.NotExistingDistritoMunicipalId);

                var distritoMunicipal = masterRepository.DistritoMunicipal.FindByCondition(d =>
                        d.DistritoMunicipalId == distritoMunicipalId).FirstOrDefault();

                var distritoMunicipalDto = mapper.Map<DistritoMunicipalDtoOut>(distritoMunicipal);
               
                return ServiceResult<DistritoMunicipalDtoOut>.ResultOk(distritoMunicipalDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<DistritoMunicipalDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<DistritoMunicipalDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
        
        public ServiceResult<IEnumerable<DistritoMunicipalDtoOut>> GetAllDistritosMunicipalesByMunicipioId(int municipioId) 
        {
            try
            {
                if (!municipioValidationService.IsExistingMunicipioId(municipioId))
                    throw new ValidationException(MunicipioMessageConstants.NotExistingMunicipioId);

                var listDistritosMunicipales = masterRepository.DistritoMunicipal.FindByCondition(d =>
                        d.MunicipioId == municipioId);

                if (listDistritosMunicipales.Count() == 0)
                    throw new ValidationException(DistritoMunicipalMessageConstants.NotExistingDistritosMunicipalesInMunicipio);

                var listDistritosMunicipalesDto = new List<DistritoMunicipalDtoOut>();

                foreach (var distritoMunicipal in listDistritosMunicipales)
                {
                    var distritoMunicipalDto = mapper.Map<DistritoMunicipalDtoOut>(distritoMunicipal);
                    listDistritosMunicipalesDto.Add(distritoMunicipalDto);
                }

                return ServiceResult<IEnumerable<DistritoMunicipalDtoOut>>.ResultOk(listDistritosMunicipalesDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IEnumerable<DistritoMunicipalDtoOut>>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<DistritoMunicipalDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }


    }
}
