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
    public class TipoUsuarioService: ITipoUsuarioService
    {
        //Clase e interfaz de validacion , interfaz de esta clase, DTOs,  mapper, mensajes constantes, dependecy intejection en startup
        readonly IMasterRepository masterRepository;
        readonly ITipoUsuarioValidationService tipoUsuarioValidationService;
        readonly IMapper mapper;

        public TipoUsuarioService(IMasterRepository masterRepository, ITipoUsuarioValidationService tipoUsuarioValidationService, IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.tipoUsuarioValidationService = tipoUsuarioValidationService;
            this.mapper = mapper;
        }

        public ServiceResult<IEnumerable<TipoUsuarioDtoOut>> GetAllTiposUsuario()
        {
            try
            {
                var listTiposUsuarios = masterRepository.TipoUsuario.GetAll();

                var listTiposUsuariosDto = new List<TipoUsuarioDtoOut>();

                foreach (var tipoUsuario in listTiposUsuarios)
                {
                    var tipoUsuarioDto = mapper.Map<TipoUsuarioDtoOut>(tipoUsuario);
                    listTiposUsuariosDto.Add(tipoUsuarioDto);
                }

                return ServiceResult<IEnumerable<TipoUsuarioDtoOut>>.ResultOk(listTiposUsuariosDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IEnumerable<TipoUsuarioDtoOut>>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<TipoUsuarioDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<TipoUsuarioDtoOut> GetTipoUsuarioByTipoUsuarioId(int tipoUsuarioId) 
        {
            try
            {
                if (!tipoUsuarioValidationService.IsExistingTipoUsuarioId(tipoUsuarioId))
                    throw new ValidationException(TipoUsuarioMessageConstants.NotExistingTipoUsuarioId);

                var tipoUsuario = masterRepository.TipoUsuario.FindByCondition(t => 
                    t.TipoUsuarioId == tipoUsuarioId).FirstOrDefault();

                var tipoUsuarioDto = mapper.Map<TipoUsuarioDtoOut>(tipoUsuario);

                return ServiceResult<TipoUsuarioDtoOut>.ResultOk(tipoUsuarioDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<TipoUsuarioDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<TipoUsuarioDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
    }
}
