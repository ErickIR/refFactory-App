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
    public class ProvinciaService : IProvinciaService
    {
        readonly IMasterRepository masterRepository;
        readonly IGeneralValidationService generalValidationService;
        readonly IProvinciaValidationService provinciaValidationService;
        readonly IMapper mapper;

        public ProvinciaService(IMasterRepository masterRepository, IGeneralValidationService generalValidationService,
            IProvinciaValidationService provinciaValidationService, IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.generalValidationService = generalValidationService;
            this.provinciaValidationService = provinciaValidationService;
            this.mapper = mapper;
        }

        public ServiceResult<int> CreateProvincia(ProvinciaDtoIn provinciaDto)
        {
            try
            {
                if (generalValidationService.IsEmptyText(provinciaDto.Nombre))
                    throw new ValidationException(ProvinciaMessageConstants.EmptyProvinciaName);

                if (provinciaValidationService.IsExistingProvinciaName(provinciaDto.Nombre))
                    throw new ValidationException(ProvinciaMessageConstants.ExistingProvinciaName);


                provinciaDto.Nombre = generalValidationService.GetRewrittenTextFirstCapitalLetter(provinciaDto.Nombre);

                var provincia = mapper.Map<Provincia>(provinciaDto);

                masterRepository.Provincia.Create(provincia);
                masterRepository.Save();

                provincia = masterRepository.Provincia.FindByCondition(r =>
                    r.Nombre == provinciaDto.Nombre).FirstOrDefault();

                return ServiceResult<int>.ResultOk(provincia.ProvinciaId);
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

        public ServiceResult<ProvinciaDtoOut> GetProvinciaByProvinciaId(int provinciaId)
        {
            try
            {
                if (!provinciaValidationService.IsExistingProvinciaId(provinciaId))
                    throw new ValidationException(ProvinciaMessageConstants.NotExistingProvinciaId);

                var provincia = masterRepository.Provincia.FindByCondition(p =>
                    p.ProvinciaId == provinciaId).FirstOrDefault();

                var provinciaDto = mapper.Map<ProvinciaDtoOut>(provincia);

                return ServiceResult<ProvinciaDtoOut>.ResultOk(provinciaDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<ProvinciaDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<ProvinciaDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<IEnumerable<ProvinciaDtoOut>> GetAllProvincias() 
        {
            try
            {
                var listProvincias = masterRepository.Provincia.GetAll();

                var listProvinciasDto = new List<ProvinciaDtoOut>();

                foreach (var provincia in listProvincias)
                {
                    var provinciaDto = mapper.Map<ProvinciaDtoOut>(provincia);
                    listProvinciasDto.Add(provinciaDto);
                }

                return ServiceResult<IEnumerable<ProvinciaDtoOut>>.ResultOk(listProvinciasDto);
            }
           
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<ProvinciaDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<int> UpdateProvincia(int provinciaId, ProvinciaDtoIn provinciaDto) 
        {
            try
            {
                if (!provinciaValidationService.IsExistingProvinciaId(provinciaId))
                    throw new ValidationException(ProvinciaMessageConstants.NotExistingProvinciaId);

                if (generalValidationService.IsEmptyText(provinciaDto.Nombre))
                    throw new ValidationException(ProvinciaMessageConstants.EmptyProvinciaName);

                if (provinciaValidationService.IsExistingProvinciaName(provinciaDto.Nombre))
                    throw new ValidationException(ProvinciaMessageConstants.ExistingProvinciaName);


                var provincia = mapper.Map<Provincia>(provinciaDto);
                provincia.ProvinciaId = provinciaId;

                masterRepository.Provincia.Update(provincia);
                masterRepository.Save();

                return ServiceResult<int>.ResultOk(provinciaId);
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
        public ServiceResult<int> DeleteProvincia(int provinciaId) 
        {
            try
            {
                if (!provinciaValidationService.IsExistingProvinciaId(provinciaId))
                    throw new ValidationException(ProvinciaMessageConstants.NotExistingProvinciaId);

                if (provinciaValidationService.IsExistingInMunicipio(provinciaId))
                    throw new ValidationException(ProvinciaMessageConstants.ProvinciaAttachedToMunicipio);

                var provincia = masterRepository.Provincia.FindByCondition(p =>
                    p.ProvinciaId == provinciaId).FirstOrDefault();

                masterRepository.Provincia.Delete(provincia);
                masterRepository.Save();
                    
                return ServiceResult<int>.ResultOk(provinciaId);
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
