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
    public class IntegranteJdVService: IIntegranteJdVService
    {
        //Clase e interfaz de validacion , interfaz de esta clase, DTOs,  mapper, mensajes constantes, dependecy intejection en startup
        readonly IMasterRepository masterRepository;
        readonly IIntegranteJdVValidationService integranteJdVValidationService;
        readonly IJuntaDeVecinosValidationService juntaDeVecinosValidationService;
        readonly IMapper mapper;

        public IntegranteJdVService(IMasterRepository masterRepository, IIntegranteJdVValidationService integranteJdVValidationService, 
            IJuntaDeVecinosValidationService juntaDeVecinosValidationService, IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.integranteJdVValidationService = integranteJdVValidationService;
            this.juntaDeVecinosValidationService = juntaDeVecinosValidationService;
            this.mapper = mapper;
        }

        private IntegranteJdVDtoOut MaptoDto(IntegranteJdV integranteJdV)
        {
            var integranteJdVDto = mapper.Map<IntegranteJdVDtoOut>(integranteJdV);

            integranteJdVDto.Usuario = GetUsuarioDto(masterRepository.Usuario
                .FindByCondition(u => u.UsuarioId == integranteJdV.UsuarioId).FirstOrDefault());

            integranteJdVDto.Rol = mapper.Map<RolDtoOut>(masterRepository.Rol
                .FindByCondition(r => r.RolId == integranteJdV.RolId).FirstOrDefault());

            return integranteJdVDto;
        }

        private UsuarioDtoOut GetUsuarioDto(Usuario usuario)
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

        public ServiceResult<IEnumerable<IntegranteJdVDtoOut>> GetAllIntegrantesJdV()
        {
            try
            {
                var listIntegrantesJdV = masterRepository.IntegranteJdV.GetAll();

                var listIntegrantesJdVDto = new List<IntegranteJdVDtoOut>();

                foreach (var integranteJdV in listIntegrantesJdV)
                {
                    var integranteJdVDto = MaptoDto(integranteJdV);
                    listIntegrantesJdVDto.Add(integranteJdVDto);
                }

                return ServiceResult<IEnumerable<IntegranteJdVDtoOut>>.ResultOk(listIntegrantesJdVDto);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<IntegranteJdVDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<IntegranteJdVDtoOut> GetIntegranteJdVByIntegranteId(int integranteId)
        {
            try
            {
                if (!integranteJdVValidationService.IsExistingIntegranteId(integranteId))
                    throw new ValidationException(IntegranteJdVMessageConstants.NotExistingIntegranteId);

                var integranteJdV = masterRepository.IntegranteJdV.FindByCondition(i =>
                    i.IntegranteId == integranteId).FirstOrDefault();

                var integranteJdVDto = MaptoDto(integranteJdV);

                return ServiceResult<IntegranteJdVDtoOut>.ResultOk(integranteJdVDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IntegranteJdVDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IntegranteJdVDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<IEnumerable<IntegranteJdVDtoOut>> GetAllIntegrantesJdVByJuntaDeVecinosId(int juntaDeVecinosId)
        {
            try
            {
                if (!juntaDeVecinosValidationService.IsExistingJuntaDeVecinosId(juntaDeVecinosId))
                    throw new ValidationException(JuntaDeVecinosMessageConstants.NotExistingJuntaDeVecinosId);

                var listIntegrantesJdV = masterRepository.IntegranteJdV.FindByCondition(i => 
                    i.JuntaDeVecinosId == juntaDeVecinosId);

                if (listIntegrantesJdV.Count() == 0)
                    throw new ValidationException(IntegranteJdVMessageConstants.NotExistingIntegranteJdVByCampos);

                var listIntegrantesJdVDto = new List<IntegranteJdVDtoOut>();

                foreach (var integranteJdV in listIntegrantesJdV)
                {
                    var integranteJdVDto = MaptoDto(integranteJdV);
                    listIntegrantesJdVDto.Add(integranteJdVDto);
                }
                return ServiceResult<IEnumerable<IntegranteJdVDtoOut>>.ResultOk(listIntegrantesJdVDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IEnumerable<IntegranteJdVDtoOut>>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<IntegranteJdVDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
    }
}
