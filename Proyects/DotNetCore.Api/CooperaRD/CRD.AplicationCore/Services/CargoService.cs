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
    public class CargoService: ICargoService
    {
        //Clase e interfaz de validacion , interfaz de esta clase, DTOs,  mapper, mensajes constantes, dependecy intejection en startup
        readonly IMasterRepository masterRepository;
        readonly ICargoValidationService cargoValidationService;
        readonly IMapper mapper;
        public CargoService(IMasterRepository masterRepository, ICargoValidationService cargoValidationService, IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.cargoValidationService = cargoValidationService;
            this.mapper = mapper;
        }

        public ServiceResult<IEnumerable<CargoDtoOut>> GetAllCargos()
        {
            try
            {
                var listCargos = masterRepository.Cargo.GetAll();

                var listCargosDto = new List<CargoDtoOut>();

                foreach (var cargo in listCargos)
                {
                    var cargoDto = mapper.Map<CargoDtoOut>(cargo);
                    listCargosDto.Add(cargoDto);
                }

                return ServiceResult<IEnumerable<CargoDtoOut>>.ResultOk(listCargosDto);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<CargoDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<CargoDtoOut> GetCargoByCargoId(int cargoId)
        {
            try
            {
                if (!cargoValidationService.IsExistingCargoId(cargoId))
                    throw new ValidationException(CargoMessageConstants.NotExistingCargoId);

                var cargo = masterRepository.Cargo.FindByCondition(e =>
                    e.CargoId == cargoId).FirstOrDefault();

                var cargoDto = mapper.Map<CargoDtoOut>(cargo);

                return ServiceResult<CargoDtoOut>.ResultOk(cargoDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<CargoDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {

                return ServiceResult<CargoDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
    }
}
