using AutoMapper;
using CRD.AplicationCore.Constants;
using CRD.AplicationCore.Interfaces;
using CRD.AplicationCore.Interfaces.Validations;
using CRD.Common.DTOs;
using CRD.Common.DTOs.DtoOut;
using CRD.Common.Enums;
using CRD.Common.Models;
using CRD.Domain.Interfaces;
using CRD.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace CRD.AplicationCore.Services
{
    public class LoginService: ILoginService
    {
        readonly IMasterRepository masterRepository;
        readonly IUsuarioValidationService usuarioValidationService;
        readonly IMapper mapper;

        public LoginService(IMasterRepository masterRepository, IUsuarioValidationService usuarioValidationService,
                IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.usuarioValidationService = usuarioValidationService;
            this.mapper = mapper;
        }

        public ServiceResult<UsuarioDtoOut> ValidateLogin(LoginDto loginDto)
        {
            try
            {
                if (!usuarioValidationService.IsValidEmail(loginDto.Email))
                    throw new ValidationException(UsuarioMessageConstants.IsInvalidEmail);

                var hashPassword = Encrypt.GetSHA256(loginDto.Password);

                var listListUsuarios = masterRepository.Usuario.GetAll();

                Usuario usuario = null;

                foreach (var usuarioTemp in listListUsuarios)
                {
                    if(usuarioTemp.Email.ToLower() == loginDto.Email.ToLower() && usuarioTemp.HashPassword == hashPassword)
                    {
                        usuario = usuarioTemp;
                        break;
                    }
                }

                if (usuario == null)
                    throw new ValidationException(LoginMessageConstants.CredentialsWrong);

                var usuarioDto = mapper.Map<UsuarioDtoOut>(usuario);

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
