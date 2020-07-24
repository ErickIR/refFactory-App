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
    public class IncidenciaService: IIncidenciaService
    {
        //Clase e interfaz de validacion , interfaz de esta clase, DTOs,  mapper, mensajes constantes, dependecy intejection en startup
        readonly IMasterRepository masterRepository;
        readonly IIncidenciaValidationService incidenciaValidationService;
        readonly IBarrioValidationService barrioValidationService;
        readonly IUsuarioValidationService usuarioValidationService;
        readonly IStatusIncidenciaValidationService statusIncidenciaValidationService;
        readonly ITipoIncidenciaValidationService tipoIncidenciaValidationService;
        readonly IGeneralValidationService generalValidationService;
        readonly IMapper mapper;

        public IncidenciaService(IMasterRepository masterRepository, IIncidenciaValidationService incidenciaValidationService, 
            IBarrioValidationService barrioValidationService, IUsuarioValidationService usuarioValidationService, 
            IStatusIncidenciaValidationService statusIncidenciaValidationService, 
            ITipoIncidenciaValidationService tipoIncidenciaValidationService, IMapper mapper,
            IGeneralValidationService generalValidationService)
        {
            this.masterRepository = masterRepository;
            this.incidenciaValidationService = incidenciaValidationService;
            this.barrioValidationService = barrioValidationService;
            this.usuarioValidationService = usuarioValidationService;
            this.statusIncidenciaValidationService = statusIncidenciaValidationService;
            this.tipoIncidenciaValidationService = tipoIncidenciaValidationService;
            this.generalValidationService = generalValidationService;
            this.mapper = mapper;
        }

        private IncidenciaDtoOut MapToDto(Incidencia incidencia)
        {
            var incidenciaDto = mapper.Map<IncidenciaDtoOut>(incidencia);

            incidenciaDto.Empleado = mapper.Map<UsuarioDtoOut>(masterRepository.Usuario.
                FindByCondition(u => u.UsuarioId == incidencia.EmpleadoId).FirstOrDefault());

            incidenciaDto.Usuario = mapper.Map<UsuarioDtoOut>(masterRepository.Usuario.
                FindByCondition(u => u.UsuarioId == incidencia.UsuarioId).FirstOrDefault());

            incidenciaDto.Status = mapper.Map<StatusIncidenciaDtoOut>(masterRepository.StatusIncidencia.
                FindByCondition(s => s.StatusIncidenciaId == incidencia.StatusId).FirstOrDefault());

            incidenciaDto.Tipo = mapper.Map<TipoIncidenciaDtoOut>(masterRepository.TipoIncidencia.
                FindByCondition(t => t.TipoIncidenciaId == incidencia.TipoId).FirstOrDefault());

            incidenciaDto.Barrio = mapper.Map<BarrioDtoOut>(masterRepository.Barrio.
                FindByCondition(b => b.BarrioId == incidencia.BarrioId).FirstOrDefault());

            incidenciaDto.Apoyos = 1 + masterRepository.IncidenciaUsuario.FindByCondition(i =>
                i.IncidenciaId == incidencia.IncidenciaId).Count();

            return incidenciaDto;
        }

        public ServiceResult<bool> CreateIncidencia(IncidenciaDtoIn incidenciaDto)
        {
            try
            {
                if (!usuarioValidationService.IsExistingUsuarioId(incidenciaDto.EmpleadoId))
                    throw new ValidationException(UsuarioMessageConstants.NotExistingUsuarioId);

                if (!usuarioValidationService.IsExistingUsuarioId(incidenciaDto.UsuarioId))
                    throw new ValidationException(UsuarioMessageConstants.NotExistingUsuarioId);

                if (!statusIncidenciaValidationService.IsExistingStatusIncidenciaId(incidenciaDto.StatusId))
                    throw new ValidationException(StatusIncidenciaMessageConstants.NotExistingStatusIncidenciaId);

                if (!barrioValidationService.IsExistingBarrioId(incidenciaDto.BarrioId))
                    throw new ValidationException(BarrioMessageConstants.NotExistingBarrioId);

                if (!tipoIncidenciaValidationService.IsExistingTipoIncidenciaId(incidenciaDto.TipoId))
                    throw new ValidationException(TipoIncidenciaMessageConstants.NotExistingTipoIncidenciaId);

                if(generalValidationService.IsEmptyText(incidenciaDto.Titulo))
                    throw new ValidationException(IncidenciaUsuarioMessageConstants.EmptyIncidenciaUsuarioTitulo);

                if (generalValidationService.IsEmptyText(incidenciaDto.Descripccion))
                    throw new ValidationException(IncidenciaUsuarioMessageConstants.EmptyIncidenciaUsuarioDescripcion);

                incidenciaDto.Titulo = generalValidationService.GetRewrittenTextFirstCapitalLetter(incidenciaDto.Titulo);
                incidenciaDto.Descripccion = generalValidationService.GetRewrittenTextFirstCapitalLetter(incidenciaDto.Descripccion);

                var incidencia = mapper.Map<Incidencia>(incidenciaDto);

                masterRepository.Incidencia.Create(incidencia);
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

        public ServiceResult<IEnumerable<IncidenciaDtoOut>> GetAllIncidencias()
        {
            try
            {
                var listIncidencias = masterRepository.Incidencia.GetAll();

                var listIncidenciasDto = new List<IncidenciaDtoOut>();

                foreach (var incidencia in listIncidencias)
                {
                    var incidenciaDto = MapToDto(incidencia);
                    listIncidenciasDto.Add(incidenciaDto);
                }

                return ServiceResult<IEnumerable<IncidenciaDtoOut>>.ResultOk(listIncidenciasDto);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<IncidenciaDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<IncidenciaDtoOut> GetIncidenciaByIncidenciaId (int incidenciaId)
        {
            try
            {
                if (!incidenciaValidationService.IsExistingIncidenciaId(incidenciaId))
                    throw new ValidationException(IncidenciaMessageConstants.NotExistingIncidenciaId);

                var incidencia = masterRepository.Incidencia.FindByCondition(i =>
                    i.IncidenciaId == incidenciaId).FirstOrDefault();

                var incidenciaDto = MapToDto(incidencia);

                return ServiceResult<IncidenciaDtoOut>.ResultOk(incidenciaDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IncidenciaDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IncidenciaDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<IEnumerable<IncidenciaDtoOut>> GetAllIncidenciasByBarrioId(int barrioId)
        {
            try
            {
                if (!barrioValidationService.IsExistingBarrioId(barrioId))
                    throw new ValidationException(BarrioMessageConstants.NotExistingBarrioId);

                var listIncidencias = masterRepository.Incidencia.FindByCondition(i => 
                    i.BarrioId == barrioId);

                if (listIncidencias.Count() == 0)
                    throw new ValidationException(IncidenciaMessageConstants.NotExistingIncidenciasByCampos);

                var listIncidenciasDto = new List<IncidenciaDtoOut>();

                foreach (var incidencia in listIncidencias)
                {
                    var incidenciaDto = MapToDto(incidencia);
                    listIncidenciasDto.Add(incidenciaDto);
                }

                return ServiceResult<IEnumerable<IncidenciaDtoOut>>.ResultOk(listIncidenciasDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IEnumerable<IncidenciaDtoOut>>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<IncidenciaDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<IEnumerable<IncidenciaDtoOut>> GetAllIncidenciasByBarrioIdAndStatusIncidenciaId(int barrioId, int statusIncidenciaId)
        {
            try
            {
                if (!barrioValidationService.IsExistingBarrioId(barrioId))
                    throw new ValidationException(BarrioMessageConstants.NotExistingBarrioId);

                if (!statusIncidenciaValidationService.IsExistingStatusIncidenciaId(statusIncidenciaId))
                    throw new ValidationException(StatusIncidenciaMessageConstants.NotExistingStatusIncidenciaId);

                var listIncidencias = masterRepository.Incidencia.FindByCondition(i =>
                    i.BarrioId == barrioId && i.StatusId == statusIncidenciaId);

                if (listIncidencias.Count() == 0)
                    throw new ValidationException(IncidenciaMessageConstants.NotExistingIncidenciasByCampos);

                var listIncidenciasDto = new List<IncidenciaDtoOut>();

                foreach (var incidencia in listIncidencias)
                {
                    var incidenciaDto = MapToDto(incidencia);
                    listIncidenciasDto.Add(incidenciaDto);
                }

                return ServiceResult<IEnumerable<IncidenciaDtoOut>>.ResultOk(listIncidenciasDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IEnumerable<IncidenciaDtoOut>>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<IncidenciaDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<IEnumerable<IncidenciaDtoOut>> GetAllIncidenciasByBarrioIdAndTipoIncidenciaId(int barrioId, int tipoIncidenciaId)
        {
            try
            {
                if (!barrioValidationService.IsExistingBarrioId(barrioId))
                    throw new ValidationException(BarrioMessageConstants.NotExistingBarrioId);

                if (!tipoIncidenciaValidationService.IsExistingTipoIncidenciaId(tipoIncidenciaId))
                    throw new ValidationException(TipoIncidenciaMessageConstants.NotExistingTipoIncidenciaId);

                var listIncidencias = masterRepository.Incidencia.FindByCondition(i =>
                    i.BarrioId == barrioId && i.TipoId == tipoIncidenciaId);

                if (listIncidencias.Count() == 0)
                    throw new ValidationException(IncidenciaMessageConstants.NotExistingIncidenciasByCampos);

                var listIncidenciasDto = new List<IncidenciaDtoOut>();

                foreach (var incidencia in listIncidencias)
                {
                    var incidenciaDto = MapToDto(incidencia);
                    listIncidenciasDto.Add(incidenciaDto);
                }

                return ServiceResult<IEnumerable<IncidenciaDtoOut>>.ResultOk(listIncidenciasDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IEnumerable<IncidenciaDtoOut>>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<IncidenciaDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<IEnumerable<IncidenciaDtoOut>> GetAllIncidenciasByUsuarioId(int usuarioId)
        {
            try
            {
                if (!usuarioValidationService.IsExistingUsuarioId(usuarioId))
                    throw new ValidationException(UsuarioMessageConstants.NotExistingUsuarioId);

                var listIncidencias = masterRepository.Incidencia.FindByCondition(i =>
                    i.UsuarioId == usuarioId);

                if (listIncidencias.Count() == 0)
                    throw new ValidationException(IncidenciaMessageConstants.NotExistingIncidenciasByCampos);

                var listIncidenciasDto = new List<IncidenciaDtoOut>();

                foreach (var incidencia in listIncidencias)
                {
                    var incidenciaDto = MapToDto(incidencia);
                    listIncidenciasDto.Add(incidenciaDto);
                }

                return ServiceResult<IEnumerable<IncidenciaDtoOut>>.ResultOk(listIncidenciasDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IEnumerable<IncidenciaDtoOut>>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<IncidenciaDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
       
    }
}
