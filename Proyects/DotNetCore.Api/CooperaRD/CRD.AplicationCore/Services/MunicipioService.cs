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
    public class MunicipioService: IMunicipioService
    {
        
        readonly IMasterRepository masterRepository;
        readonly IGeneralValidationService generalValidationService;
        readonly IMunicipioValidationService municipioValidationService;
        readonly IProvinciaValidationService provinciaValidationService;
        readonly IBarrioValidationService barrioValidationService;
        readonly IMapper mapper;

        public MunicipioService(IMasterRepository masterRepository, IGeneralValidationService generalValidationService, 
            IMunicipioValidationService municipioValidationService,
            IProvinciaValidationService provinciaValidationService, IMapper mapper,
            IBarrioValidationService barrioValidationService)
        {
            this.masterRepository = masterRepository;
            this.generalValidationService = generalValidationService;
            this.municipioValidationService = municipioValidationService;
            this.provinciaValidationService = provinciaValidationService;
            this.mapper = mapper;
            this.barrioValidationService = barrioValidationService;
        }

        public ServiceResult<int> CreateMunicipio(MunicipioDtoIn municipioDto)
        {
            try
            {
                if (generalValidationService.IsEmptyText(municipioDto.Nombre))
                    throw new ValidationException(MunicipioMessageConstants.EmptyMunicipioName);

                if (municipioValidationService.IsExistingMunicipioName(municipioDto.Nombre))
                    throw new ValidationException(MunicipioMessageConstants.ExistingMunicipioName);

                if (!provinciaValidationService.IsExistingProvinciaId(municipioDto.ProvinciaId))
                    throw new ValidationException(ProvinciaMessageConstants.NotExistingProvinciaId);

                municipioDto.Nombre = generalValidationService.GetRewrittenTextFirstCapitalLetter(municipioDto.Nombre);

                var municipio = mapper.Map<Municipio>(municipioDto);

                masterRepository.Municipio.Create(municipio);
                masterRepository.Save();

                municipio = masterRepository.Municipio.FindByCondition(m =>
                    m.Nombre == municipioDto.Nombre).FirstOrDefault();

                return ServiceResult<int>.ResultOk(municipio.MunicipioId);
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

        public ServiceResult<IEnumerable<MunicipioDtoOut>> GetAllMunicipios()
        {
            try
            {
                var listMunicipios = masterRepository.Municipio.GetAll();

                var listMunicipiosDto = new List<MunicipioDtoOut>();

                foreach (var municipio in listMunicipios)
                {
                    var municipioDto = mapper.Map<MunicipioDtoOut>(municipio);
                    listMunicipiosDto.Add(municipioDto);
                }
                return ServiceResult<IEnumerable<MunicipioDtoOut>>.ResultOk(listMunicipiosDto);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<MunicipioDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
        
        public ServiceResult<MunicipioDtoOut> GetMunicipioByMunicipioId(int municipioId)
        {
            try
            {
                if (!municipioValidationService.IsExistingMunicipioId(municipioId))
                    throw new ValidationException(MunicipioMessageConstants.NotExistingMunicipioId);

                var municipio = masterRepository.Municipio.FindByCondition(m =>
                    m.MunicipioId == municipioId).FirstOrDefault();

                var municipioDto = mapper.Map<MunicipioDtoOut>(municipio);

                return ServiceResult<MunicipioDtoOut>.ResultOk(municipioDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<MunicipioDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<MunicipioDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<MunicipioDtoOut> GetMunicipioByBarrioId(int barrioId)
        {
            try
            {
                if (!barrioValidationService.IsExistingBarrioId(barrioId))
                    throw new ValidationException(BarrioMessageConstants.NotExistingBarrioId);

                var barrio = masterRepository.Barrio.FindByCondition(b =>
                    b.BarrioId == barrioId).FirstOrDefault();
                
                var sector = masterRepository.Sector.FindByCondition(s =>
                    s.SectorId == barrio.SectorId).FirstOrDefault();

                var seccion = masterRepository.Seccion.FindByCondition(s => 
                    s.SeccionId == sector.SeccionId).FirstOrDefault();

                var distritoMunicipal = masterRepository.DistritoMunicipal.FindByCondition(d =>
                    d.DistritoMunicipalId == seccion.DistritoMunicipalId).FirstOrDefault();

                var municipio = masterRepository.Municipio.FindByCondition(m =>
                    m.MunicipioId == distritoMunicipal.MunicipioId).FirstOrDefault();

                var municipioDto = mapper.Map<MunicipioDtoOut>(municipio);

                return ServiceResult<MunicipioDtoOut>.ResultOk(municipioDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<MunicipioDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<MunicipioDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<int> UpdateMunicipio(int municipioId,MunicipioDtoIn municipioDto)
        {
            try
            {
                if (!municipioValidationService.IsExistingMunicipioId(municipioId))
                    throw new ValidationException(MunicipioMessageConstants.NotExistingMunicipioId);

                if (generalValidationService.IsEmptyText(municipioDto.Nombre))
                    throw new ValidationException(MunicipioMessageConstants.EmptyMunicipioName);

                if (municipioValidationService.IsExistingMunicipioName(municipioDto.Nombre))
                    throw new ValidationException(MunicipioMessageConstants.ExistingMunicipioName);

                if (!provinciaValidationService.IsExistingProvinciaId(municipioDto.ProvinciaId))
                    throw new ValidationException(ProvinciaMessageConstants.NotExistingProvinciaId);

                var municipio = mapper.Map<Municipio>(municipioDto);
                municipio.MunicipioId = municipioId;

                masterRepository.Municipio.Update(municipio);
                masterRepository.Save();

                return ServiceResult<int>.ResultOk(municipioId);
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

        public ServiceResult<int> DeleteMunicipio(int municipioId)
        {
            try
            {
                if (!municipioValidationService.IsExistingMunicipioId(municipioId))
                    throw new ValidationException(MunicipioMessageConstants.NotExistingMunicipioId);

                if (municipioValidationService.IsExistingInDistritoNacional(municipioId))
                    throw new ValidationException(MunicipioMessageConstants.MunicipioAttachedToDistritoMunicipal);

                if (municipioValidationService.IsExistingInEntidadMunicipal(municipioId))
                    throw new ValidationException(MunicipioMessageConstants.MunicipioAttachedToEntidadMunicipal);

                var municipio = masterRepository.Municipio.FindByCondition(m =>
                    m.MunicipioId == municipioId).FirstOrDefault();

                masterRepository.Municipio.Delete(municipio);
                masterRepository.Save();

                return ServiceResult<int>.ResultOk(0);
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
        
    }
}
