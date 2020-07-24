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
    public class IncidenciaUsuarioService: IIncidenciaUsuarioService
    {
        
        readonly IMasterRepository masterRepository;
        readonly IIncidenciaUsuarioValidationService incidenciaUsuarioValidationService;
        readonly IIncidenciaValidationService incidenciaValidationService;
        readonly IUsuarioValidationService usuarioValidationService;
        readonly IMapper mapper;

        public IncidenciaUsuarioService(IMasterRepository masterRepository, IIncidenciaUsuarioValidationService incidenciaUsuarioValidationService,
            IIncidenciaValidationService incidenciaValidationService, IUsuarioValidationService usuarioValidationService , IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.incidenciaUsuarioValidationService = incidenciaUsuarioValidationService;
            this.incidenciaValidationService = incidenciaValidationService;
            this.usuarioValidationService = usuarioValidationService;
            this.mapper = mapper;
        }

        public ServiceResult<bool> CreateIncidenciaUsuario(IncidenciaUsuarioDtoIn incidenciaUsuarioDto)
        {
            try
            {
                if (!incidenciaValidationService.IsExistingIncidenciaId(incidenciaUsuarioDto.IncidenciaId))
                    throw new ValidationException(IncidenciaMessageConstants.NotExistingIncidenciaId);

                if (!usuarioValidationService.IsExistingUsuarioId(incidenciaUsuarioDto.UsuarioId))
                    throw new ValidationException(UsuarioMessageConstants.NotExistingUsuarioId);

                if (incidenciaUsuarioValidationService.IsExisingApoyo(incidenciaUsuarioDto.IncidenciaId, incidenciaUsuarioDto.UsuarioId))
                    throw new ValidationException(IncidenciaUsuarioMessageConstants.ExistingApoyo);

                var incidenciaUsuario = mapper.Map<IncidenciaUsuario>(incidenciaUsuarioDto);

                masterRepository.IncidenciaUsuario.Create(incidenciaUsuario);
                masterRepository.Save();

                return ServiceResult<bool>.ResultOk(true);
            }
            catch (ValidationException e)
            {
                return ServiceResult<bool>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<bool>.ResultFailed(ResponseCode.Error, e.Message);
            }
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
