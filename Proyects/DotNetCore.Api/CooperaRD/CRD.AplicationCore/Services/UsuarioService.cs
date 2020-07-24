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
    public class UsuarioService: IUsuarioService
    {
        readonly IMasterRepository masterRepository;
        readonly IUsuarioValidationService usuarioValidationService;
        readonly ITipoDocumentoValidationService tipoDocumentoValidationService;
        readonly IBarrioValidationService barrioValidationService;
        readonly ITipoUsuarioValidationService tipoUsuarioValidationService;
        readonly IGeneralValidationService generalValidationService;
        readonly IMapper mapper;

        public UsuarioService(IMasterRepository masterRepository, IUsuarioValidationService usuarioValidationService, 
            ITipoDocumentoValidationService tipoDocumentoValidationService, IBarrioValidationService barrioValidationService, 
            ITipoUsuarioValidationService tipoUsuarioValidationService, IMapper mapper, IGeneralValidationService generalValidationService)
        {
            this.masterRepository = masterRepository;
            this.usuarioValidationService = usuarioValidationService;
            this.tipoDocumentoValidationService = tipoDocumentoValidationService;
            this.barrioValidationService = barrioValidationService;
            this.tipoUsuarioValidationService = tipoUsuarioValidationService;
            this.generalValidationService = generalValidationService;
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

        public ServiceResult<bool> CreateUsuario(UsuarioDtoIn usuarioDto)
        {
            try
            {
                if (!tipoUsuarioValidationService.IsExistingTipoUsuarioId(usuarioDto.TipoUsuarioId))
                    throw new ValidationException(TipoUsuarioMessageConstants.NotExistingTipoUsuarioId);

                if (!tipoDocumentoValidationService.IsExistingTipoDocumentoId(usuarioDto.TipoDocumentoId))
                    throw new ValidationException(TipoDocumentoMessageConstants.NotExistingTipoDocumentoId);

                if (!barrioValidationService.IsExistingBarrioId(usuarioDto.BarrioId))
                    throw new ValidationException(BarrioMessageConstants.NotExistingBarrioId);

                if (generalValidationService.IsEmptyText(usuarioDto.Nombres))
                    throw new ValidationException(UsuarioMessageConstants.EmptyUsuarioNombres);

                if (generalValidationService.IsEmptyText(usuarioDto.Apellidos))
                    throw new ValidationException(UsuarioMessageConstants.EmptyUsuarioApellidos);

                if (generalValidationService.IsEmptyText(usuarioDto.Documento))
                    throw new ValidationException(UsuarioMessageConstants.EmptyUsuarioDocumento);

                if (generalValidationService.IsEmptyText(usuarioDto.Email))
                    throw new ValidationException(UsuarioMessageConstants.EmptyUsuarioEmail);

                if (generalValidationService.IsEmptyText(usuarioDto.HashPassword))
                    throw new ValidationException(UsuarioMessageConstants.EmptyUsuarioPassword);

                if (usuarioValidationService.IsExistingDocumento(usuarioDto.TipoDocumentoId, usuarioDto.Documento))
                    throw new ValidationException(UsuarioMessageConstants.IsExistingDocumento);

                if (!usuarioValidationService.IsValidEmail(usuarioDto.Email))
                    throw new ValidationException(UsuarioMessageConstants.IsInvalidEmail);

                if (usuarioValidationService.IsExistingEmail(usuarioDto.Email))
                    throw new ValidationException(UsuarioMessageConstants.IsExistingEmail);
                
                usuarioDto.Nombres = generalValidationService.GetRewrittenTextFirstCapitalLetter(usuarioDto.Nombres);
                usuarioDto.Apellidos = generalValidationService.GetRewrittenTextFirstCapitalLetter(usuarioDto.Apellidos);
                usuarioDto.Email = usuarioDto.Email.ToLower();

                usuarioDto.HashPassword = Encrypt.GetSHA256(usuarioDto.HashPassword);

                var usuario = mapper.Map<Usuario>(usuarioDto);

                masterRepository.Usuario.Create(usuario);
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
