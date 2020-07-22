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
    public class SectorService: ISectorService
    {
        //Clase e interfaz de validacion , interfaz de esta clase, DTOs,  mapper, mensajes constantes, dependecy intejection en startup

        readonly IMasterRepository masterRepository;
        readonly ISectorValidationService sectorValidationService;
        readonly ISeccionValidationService seccionValidationService;
        readonly IMapper mapper;

        public SectorService(IMasterRepository masterRepository, ISectorValidationService sectorValidationService,
               ISeccionValidationService seccionValidationService, IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.sectorValidationService = sectorValidationService;
            this.seccionValidationService = seccionValidationService;
            this.mapper = mapper;
        }

        public ServiceResult<IEnumerable<SectorDtoOut>> GetAllSectores()
        {
            try
            {

                var listSectores = masterRepository.Sector.GetAll();

                var listSectoresDto = new List<SectorDtoOut>();

                foreach (var sector in listSectores)
                {
                    var sectorDto = mapper.Map<SectorDtoOut>(sector);
                    listSectoresDto.Add(sectorDto);
                }

                return ServiceResult<IEnumerable<SectorDtoOut>>.ResultOk(listSectoresDto);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<SectorDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
        public ServiceResult<SectorDtoOut> GetSectorBySectorId(int sectorId)
        {
            try
            {
                if (!sectorValidationService.IsExistingSectorId(sectorId))
                    throw new ValidationException(SeccionMessageConstants.NotExistingSeccionId);

                var sector = masterRepository.Sector.FindByCondition(s => 
                    s.SectorId == sectorId).FirstOrDefault();

                var sectorDto = mapper.Map<SectorDtoOut>(sector);

                return ServiceResult<SectorDtoOut>.ResultOk(sectorDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<SectorDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<SectorDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
        public ServiceResult<IEnumerable<SectorDtoOut>> GetAllSectoresBySeccionId(int seccionId) 
        {
            try
            {
                if (!seccionValidationService.IsExistingSeccionId(seccionId))
                    throw new ValidationException(SeccionMessageConstants.NotExistingSeccionId);

                var listSectores = masterRepository.Sector.FindByCondition(s =>
                    s.SeccionId == seccionId);

                if (listSectores.Count() == 0)
                    throw new ValidationException(SectorMessageConstants.NotExistingSectorInSeccion);

                var listSectoresDto = new List<SectorDtoOut>();

                foreach (var sector in listSectores)
                {
                    var sectorDto = mapper.Map<SectorDtoOut>(sector);
                    listSectoresDto.Add(sectorDto);
                }

                return ServiceResult<IEnumerable<SectorDtoOut>>.ResultOk(listSectoresDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IEnumerable<SectorDtoOut>>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<SectorDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

    }
}
