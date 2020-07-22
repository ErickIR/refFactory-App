using AutoMapper;
using CRD.AplicationCore.Constants;
using CRD.AplicationCore.Interfaces;
using CRD.AplicationCore.Interfaces.Validations;
using CRD.Common.DTOs.DtoOut;
using CRD.Common.Enums;
using CRD.Common.Models;
using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CRD.AplicationCore.Services
{
    public class EntidadMunicipalService: IEntidadMunicipalService
    {
        //Clase e interfaz de validacion , interfaz de esta clase, DTOs,  mapper, mensajes constantes, dependecy intejection en startup

        readonly IMasterRepository masterRepository;
        readonly IEntidadMunicipalValidationService entidadMunicipalValidationService;
        readonly IMunicipioValidationService municipioValidationService;
        readonly IMapper mapper;

        public EntidadMunicipalService(IMasterRepository masterRepository, IEntidadMunicipalValidationService entidadMunicipalValidationService, IMunicipioValidationService municipioValidationService, IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.entidadMunicipalValidationService = entidadMunicipalValidationService;
            this.municipioValidationService = municipioValidationService;
            this.mapper = mapper;
        }

        private  EntidadMunicipalDtoOut MapToDto(EntidadMunicipal entidadMunicipal)
        {
            var entidadMunicipalDto = mapper.Map<EntidadMunicipalDtoOut>(entidadMunicipal);

            entidadMunicipalDto.Cargo = mapper.Map<CargoDtoOut>(masterRepository.Cargo.
                FindByCondition(c => c.CargoId == entidadMunicipal.CargoId).FirstOrDefault());

            entidadMunicipalDto.TipoDocumento = mapper.Map<TipoDocumentoDtoOut>(masterRepository.TipoDocumento.
                FindByCondition(t => t.TipoDocumentoId == entidadMunicipal.TipoDocumentoId).FirstOrDefault());

            entidadMunicipalDto.Municipio = mapper.Map<MunicipioDtoOut>(masterRepository.Municipio.
                FindByCondition(m => m.MunicipioId == entidadMunicipal.MunicipioId).FirstOrDefault());

            return entidadMunicipalDto;
        }

        public ServiceResult<IEnumerable<EntidadMunicipalDtoOut>> GetAllEntidadesMunicipales()
        {
            try
            {
                var listEntidadesMunicipales = masterRepository.EntidadMunicipal.GetAll();

                var listEntidadesMunicipalesDto = new List<EntidadMunicipalDtoOut>();

                foreach (var entidadMunicipal in listEntidadesMunicipales)
                {
                    var entidadMunicipalDto = MapToDto(entidadMunicipal);
                   
                    listEntidadesMunicipalesDto.Add(entidadMunicipalDto);
                }

                return ServiceResult<IEnumerable<EntidadMunicipalDtoOut>>.ResultOk(listEntidadesMunicipalesDto);
            }
            
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<EntidadMunicipalDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
        
        public ServiceResult<EntidadMunicipalDtoOut> GetEntidadMunicipalByEntidadMunicipalId(int entidadMunicipalId)
        {
            try
            {
                if (!entidadMunicipalValidationService.IsExistingEntidadMunicipalId(entidadMunicipalId))
                    throw new ValidationException(EntidadMunicipalMessageConstants.NotExistingEntidadMunicipalId);

                var entidadMunicipal = masterRepository.EntidadMunicipal.FindByCondition(e => 
                    e.EntidadMunicipalId == entidadMunicipalId).FirstOrDefault();

                var entidadMunicipalDto = MapToDto(entidadMunicipal);

                return ServiceResult<EntidadMunicipalDtoOut>.ResultOk(entidadMunicipalDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<EntidadMunicipalDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<EntidadMunicipalDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<IEnumerable<EntidadMunicipalDtoOut>> GetAllEntidadesMunicipalesByMunicipioId(int municipioId)
        {
            try
            {
                if (!municipioValidationService.IsExistingMunicipioId(municipioId))
                    throw new ValidationException(MunicipioMessageConstants.NotExistingMunicipioId);

                var listEntidadesMunicipales = masterRepository.EntidadMunicipal.FindByCondition(e =>
                    e.MunicipioId == municipioId);

                if (listEntidadesMunicipales.Count() == 0)
                    throw new ValidationException(EntidadMunicipalMessageConstants.NotExistingEntidadMunicipalInMunicipio);

                var listEntidadesMunicipalesDto = new List<EntidadMunicipalDtoOut>();

                foreach (var entidadMunicipal in listEntidadesMunicipales)
                {
                    var entidadMunicipalDto = MapToDto(entidadMunicipal);

                    listEntidadesMunicipalesDto.Add(entidadMunicipalDto);
                }

                return ServiceResult<IEnumerable<EntidadMunicipalDtoOut>>.ResultOk(listEntidadesMunicipalesDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IEnumerable<EntidadMunicipalDtoOut>>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<EntidadMunicipalDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
    }
}
