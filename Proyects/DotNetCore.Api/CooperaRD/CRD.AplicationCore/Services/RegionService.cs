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

namespace CRD.AplicationCore.Services
{
    public class RegionService: IRegionService
    {
        readonly IMasterRepository masterRepository;
        readonly IGeneralValidationService generalValidationService;
        readonly IRegionValidationService regionValidationService;
        readonly IMapper mapper;

        public RegionService(IMasterRepository masterRepository, IGeneralValidationService generalValidationService,
            IRegionValidationService regionValidationService,  IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.generalValidationService = generalValidationService;
            this.regionValidationService = regionValidationService;
            this.mapper = mapper;
        }

        public ServiceResult<int> CreateRegion(string nombre)
        {
            try
            {
                if(generalValidationService.IsEmptyText(nombre))
                    throw new ValidationException(RegionMessageConstants.EmptyRegionName);

                if (regionValidationService.IsExistingRegionName(nombre))
                    throw new ValidationException(RegionMessageConstants.ExistingRegionName);

                nombre = generalValidationService.GetRewrittenTextFirstCapitalLetter(nombre);
                var region = new Region();
                 
                region.Nombre = nombre;

                masterRepository.Region.Create(region);
                masterRepository.Save();

                region = masterRepository.Region.FindByCondition(r =>
                    r.Nombre == nombre).FirstOrDefault();

                return ServiceResult<int>.ResultOk(region.RegionId);
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

        public ServiceResult<RegionDtoOut> GetRegionByRegionId(int regionId)
        {
            try
            {
                if (!regionValidationService.IsExistingRegionId(regionId))
                    throw new ValidationException(RegionMessageConstants.NotExistingRegionId);

                var region = masterRepository.Region.FindByCondition(r =>
                    r.RegionId == regionId).FirstOrDefault();

                var regionDto = mapper.Map<RegionDtoOut>(region);

                return ServiceResult<RegionDtoOut>.ResultOk(regionDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<RegionDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<RegionDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<IEnumerable<RegionDtoOut>> GetAllRegiones()
        {
            try
            {
                var listRegiones = masterRepository.Region.GetAll();

                var listRegionesDto = new List<RegionDtoOut>();

                foreach (var region in listRegiones)
                {
                    var regionDto = mapper.Map<RegionDtoOut>(region);
                    listRegionesDto.Add(regionDto);
                }
                return ServiceResult<IEnumerable<RegionDtoOut>>.ResultOk(listRegionesDto);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<RegionDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<int> UpdateRegion(int regionId, string nombre)
        {
            
            try
            {
                if (!regionValidationService.IsExistingRegionId(regionId))
                    throw new ValidationException(RegionMessageConstants.NotExistingRegionId);

                if (generalValidationService.IsEmptyText(nombre))
                    throw new ValidationException(RegionMessageConstants.EmptyRegionName);

                if (regionValidationService.IsExistingRegionName(nombre))
                    throw new ValidationException(RegionMessageConstants.ExistingRegionName);

                var region = masterRepository.Region.FindByCondition(r =>
                    r.RegionId == regionId).FirstOrDefault();

                region.Nombre = generalValidationService.GetRewrittenTextFirstCapitalLetter(nombre);

                masterRepository.Region.Update(region);
                masterRepository.Save();

                return ServiceResult<int>.ResultOk(regionId);
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

        public ServiceResult<int> DeleteRegion(int regionId) 
        {
            try
            {
                if (!regionValidationService.IsExistingRegionId(regionId))
                    throw new ValidationException(RegionMessageConstants.NotExistingRegionId);

                if (regionValidationService.IsExistingInProvincia(regionId))
                    throw new ValidationException(RegionMessageConstants.RegionAttachedToProvincia);

                var region = masterRepository.Region.FindByCondition(r =>
                    r.RegionId == regionId).FirstOrDefault();

                masterRepository.Region.Delete(region);
                masterRepository.Save();

                return ServiceResult<int>.ResultOk(regionId);
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
