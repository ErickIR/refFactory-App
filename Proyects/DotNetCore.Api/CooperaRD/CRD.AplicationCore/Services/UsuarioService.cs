using AutoMapper;
using CRD.AplicationCore.Constants;
using CRD.AplicationCore.Interfaces;
using CRD.AplicationCore.Interfaces.Validations;
using CRD.AplicationCore.Validations;
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
    public class UsuarioService: IUsuarioService
    {
        //Clase e interfaz de validacion , interfaz de esta clase, DTOs,  mapper, mensajes constantes, dependecy intejection en startup
        readonly IMasterRepository masterRepository;
        readonly IUsuarioValidationService usuarioValidationService;
        readonly IMapper mapper;

        public UsuarioService(IMasterRepository masterRepository, 
            IUsuarioValidationService usuarioValidationService, IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.usuarioValidationService = usuarioValidationService;
            this.mapper = mapper;
        }

        private UsuarioDtoOut MapToDto(Usuario usuario)
        {
            var usuarioDto = mapper.Map<UsuarioDtoOut>(usuario);

            usuarioDto.Barrio = mapper.Map<BarrioDtoOut>(masterRepository.Barrio.
                FindByCondition(b => b.BarrioId == usuario.BarrioId).FirstOrDefault());

            usuarioDto.TipoDocumento = mapper.Map<TipoDocumentoDtoOut>(masterRepository.TipoDocumento.
                FindByCondition(t => t.TipoDocumentoId == usuario.TipoDocumentoId).FirstOrDefault());

            usuarioDto.TipoUsuario = mapper.Map<TipoUsuarioDtoOut>(masterRepository.TipoUsuario.
                FindByCondition(t => t.TipoUsuarioId == usuario.TipoUsuarioId).FirstOrDefault());

            return usuarioDto;
        }

        public ServiceResult<IEnumerable<UsuarioDtoOut>> GetAllUsuarios()
        {
            try
            {
                var listUsuarios = masterRepository.Usuario.GetAll();

                var listUsuariosDto = new List<UsuarioDtoOut>();

                foreach (var usuario in listUsuarios)
                {
                    var usuarioDto = MapToDto(usuario);
                    listUsuariosDto.Add(usuarioDto);
                }
                return ServiceResult<IEnumerable<UsuarioDtoOut>>.ResultOk(listUsuariosDto);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<UsuarioDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<UsuarioDtoOut> GetUsuarioByUsuarioId(int usuarioId)
        {
            try
            {
                if (!usuarioValidationService.IsExistingUsuarioId(usuarioId))
                    throw new ValidationException(UsuarioMessageConstants.NotExistingUsuarioId);

                var usuario = masterRepository.Usuario.FindByCondition(u =>
                        u.UsuarioId == usuarioId).FirstOrDefault();

                var usuarioDto = MapToDto(usuario);

                return ServiceResult<UsuarioDtoOut>.ResultOk(usuarioDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<UsuarioDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<UsuarioDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
    }
}
