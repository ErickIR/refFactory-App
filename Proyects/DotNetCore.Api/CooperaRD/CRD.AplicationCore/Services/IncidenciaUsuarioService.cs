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
    public class IncidenciaUsuarioService: IIncidenciaUsuarioService
    {
        //Clase e interfaz de validacion , interfaz de esta clase, DTOs,  mapper, mensajes constantes, dependecy intejection en startup
        readonly IMasterRepository masterRepository;
        readonly IIncidenciaUsuarioValidationService incidenciaUsuarioValidationService;
        readonly IIncidenciaValidationService incidenciaValidationService;
        readonly IMapper mapper;

        public IncidenciaUsuarioService(IMasterRepository masterRepository, IIncidenciaUsuarioValidationService incidenciaUsuarioValidationService,
            IIncidenciaValidationService incidenciaValidationService, IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.incidenciaUsuarioValidationService = incidenciaUsuarioValidationService;
            this.incidenciaValidationService = incidenciaValidationService;
            this.mapper = mapper;
        }

        public ServiceResult<IEnumerable<IncidenciaUsuarioDtoOut>> GetAllIncidenciasUsuarios()
        {
            try
            {
                var listIncidenciasUsuarios = masterRepository.IncidenciaUsuario.GetAll();

                var listIncidenciasUsuariosDto = new List<IncidenciaUsuarioDtoOut>();

                foreach (var incidenciaUsuario in listIncidenciasUsuarios)
                {
                    var incidenciaUsuarioDto = mapper.Map<IncidenciaUsuarioDtoOut>(incidenciaUsuario);
                    listIncidenciasUsuariosDto.Add(incidenciaUsuarioDto);
                }

                return ServiceResult<IEnumerable<IncidenciaUsuarioDtoOut>>.ResultOk(listIncidenciasUsuariosDto);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<IncidenciaUsuarioDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<IncidenciaUsuarioDtoOut> GetIncidenciaUsuarioByIncidenciaUsuarioId(int incidenciaUsuarioId)
        {
            try
            {
                if (!incidenciaUsuarioValidationService.IsExistingIncidenciaUsuarioId(incidenciaUsuarioId))
                    throw new ValidationException(IncidenciaUsuarioMessageConstants.NotExistingIncidenciaUsuarioId);

                var incidenciaUsuario = masterRepository.IncidenciaUsuario.FindByCondition(i =>
                    i.IncidenciaUsuarioId == incidenciaUsuarioId).FirstOrDefault();

                var incidenciaUsuarioDto = mapper.Map<IncidenciaUsuarioDtoOut>(incidenciaUsuario);
                return ServiceResult<IncidenciaUsuarioDtoOut>.ResultOk(incidenciaUsuarioDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IncidenciaUsuarioDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IncidenciaUsuarioDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<IEnumerable<IncidenciaUsuarioDtoOut>> GetAllIncidenciasUsuariosByIncidenciaId(int incidenciaId)
        {
            try
            {
                if (!incidenciaValidationService.IsExistingIncidenciaId(incidenciaId))
                    throw new ValidationException(IncidenciaMessageConstants.NotExistingIncidenciaId);

                var listIncidenciasUsuarios = masterRepository.IncidenciaUsuario.FindByCondition(i =>
                    i.IncidenciaId ==incidenciaId);

                if (listIncidenciasUsuarios.Count() == 0)
                    throw new ValidationException(IncidenciaUsuarioMessageConstants.NotExistingIncidenciasUsuarioByCampos);

                var listIncidenciasUsuariosDto = new List<IncidenciaUsuarioDtoOut>();

                foreach (var incidenciaUsuario in listIncidenciasUsuarios)
                {
                    var incidenciaUsuarioDto = mapper.Map<IncidenciaUsuarioDtoOut>(incidenciaUsuario);
                    listIncidenciasUsuariosDto.Add(incidenciaUsuarioDto);
                }

                return ServiceResult<IEnumerable<IncidenciaUsuarioDtoOut>>.ResultOk(listIncidenciasUsuariosDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IEnumerable<IncidenciaUsuarioDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<IncidenciaUsuarioDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
    }
}
