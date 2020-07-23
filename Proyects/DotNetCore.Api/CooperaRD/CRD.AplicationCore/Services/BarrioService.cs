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
    public class BarrioService : IBarrioService
    {
        //Clase e interfaz de validacion , interfaz de esta clase, DTOs,  mapper, mensajes constantes, dependecy intejection en startup

        readonly IMasterRepository masterRepository;
        readonly IBarrioValidationService barrioValidationService;
        readonly ISectorValidationService sectorValidationService;
        readonly IDistritoMunicipalValidationService distritoMunicipalValidationService;
        readonly IMapper mapper;

        public BarrioService(IMasterRepository masterRepository, IBarrioValidationService barrioValidationService, 
            ISectorValidationService sectorValidationService, IDistritoMunicipalValidationService distritoMunicipalValidationService, 
            IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.barrioValidationService = barrioValidationService;
            this.sectorValidationService = sectorValidationService;
            this.distritoMunicipalValidationService = distritoMunicipalValidationService;
            this.mapper = mapper;
        }

        public ServiceResult<IEnumerable<BarrioDtoOut>> GetAllBarrios()
        {
            try
            {
                var listBarrios = masterRepository.Barrio.GetAll();

                var listBarriosDto = new List<BarrioDtoOut>();

                foreach (var barrio in listBarrios)
                {
                    var barrioDto = mapper.Map<BarrioDtoOut>(barrio);
                    listBarriosDto.Add(barrioDto);
                }

                return ServiceResult<IEnumerable<BarrioDtoOut>>.ResultOk(listBarriosDto);
            }
            
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<BarrioDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<BarrioDtoOut> GetBarrioByBarrioId(int barrioId)
        {   
            try
            {
                if (!barrioValidationService.IsExistingBarrioId(barrioId))
                    throw new ValidationException(BarrioMessageConstants.NotExistingBarrioId);

                var barrio = masterRepository.Barrio.FindByCondition(b =>
                    b.BarrioId == barrioId).FirstOrDefault();

                var barrioDto = mapper.Map<BarrioDtoOut>(barrio);

                return ServiceResult<BarrioDtoOut>.ResultOk(barrioDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<BarrioDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<BarrioDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<IEnumerable<BarrioDtoOut>> GetAllBarriosBySectorId(int sectorId)
        {
            try
            {
                if (!sectorValidationService.IsExistingSectorId(sectorId))
                    throw new ValidationException(SeccionMessageConstants.NotExistingSeccionId);

                var listBarrios = masterRepository.Barrio.FindByCondition(b =>
                    b.SectorId == sectorId);

                if (listBarrios.Count() == 0)
                    throw new ValidationException(BarrioMessageConstants.NotExistingBarrioInSector);

                var listBarriosDto = new List<BarrioDtoOut>();

                foreach (var barrio in listBarrios)
                {
                    var barrioDto = mapper.Map<BarrioDtoOut>(barrio);
                    listBarriosDto.Add(barrioDto);
                }

                return ServiceResult<IEnumerable<BarrioDtoOut>>.ResultOk(listBarriosDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IEnumerable<BarrioDtoOut>>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<BarrioDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<IEnumerable<BarrioDtoOut>> GetAllBarriosByDistritoMunicipalId(int distritoMunicipalId)
        {
            try
            {
                if (!distritoMunicipalValidationService.IsExistingDistritoMunicipalId(distritoMunicipalId))
                    throw new ValidationException(DistritoMunicipalMessageConstants.NotExistingDistritoMunicipalId);

                var listSecciones = masterRepository.Seccion.FindByCondition(s => 
                    s.DistritoMunicipalId == distritoMunicipalId);

                var listSectores = new List<Sector>();

                foreach (var seccion in listSecciones)
                {
                    var listSectoresTemp = masterRepository.Sector.FindByCondition(s =>
                        s.SeccionId == seccion.SeccionId);

                    foreach (var sector in listSectoresTemp)
                    {
                        listSectores.Add(sector);
                    }
                }

                var listBarrios = new List<Barrio>();

                foreach (var sector in listSectores)
                {
                    var listBarriosTemp = masterRepository.Barrio.FindByCondition(b =>
                        b.SectorId == sector.SectorId);

                    foreach (var barrio in listBarriosTemp)
                    {
                        listBarrios.Add(barrio);
                    }
                }

                if (listBarrios.Count() == 0)
                    throw new ValidationException(BarrioMessageConstants.NotExistingBarrioInSector);

                var listBarriosDto = new List<BarrioDtoOut>();

                foreach (var barrio in listBarrios)
                {
                    var barrioDto = mapper.Map<BarrioDtoOut>(barrio);
                    listBarriosDto.Add(barrioDto);
                }

                return ServiceResult<IEnumerable<BarrioDtoOut>>.ResultOk(listBarriosDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IEnumerable<BarrioDtoOut>>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<BarrioDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

    }
}
