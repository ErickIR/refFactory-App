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
    public class JuntaDeVecinosService: IJuntaDeVecinosService
    {
        //Clase e interfaz de validacion , interfaz de esta clase, DTOs,  mapper, mensajes constantes, dependecy intejection en startup 
        readonly IMasterRepository masterRepository;
        readonly IJuntaDeVecinosValidationService juntaDeVecinosValidationService;
        readonly IBarrioValidationService barrioValidationService;
        readonly IDistritoMunicipalValidationService distritoMunicipalValidationService;
        readonly IMapper mapper;

        public JuntaDeVecinosService(IMasterRepository masterRepository, IJuntaDeVecinosValidationService juntaDeVecinosValidationService,
            IBarrioValidationService barrioValidationService, IDistritoMunicipalValidationService distritoMunicipalValidationService, IMapper mapper)
        {
            this.masterRepository = masterRepository;
            this.juntaDeVecinosValidationService = juntaDeVecinosValidationService;
            this.barrioValidationService = barrioValidationService;
            this.distritoMunicipalValidationService = distritoMunicipalValidationService;
            this.mapper = mapper;
        }

        private JuntaDeVecinosDtoOut MapToDto(JuntaDeVecinos juntaDeVecinos)
        {
            var juntaDeVecinosDto = mapper.Map<JuntaDeVecinosDtoOut>(juntaDeVecinos);

            juntaDeVecinosDto.Barrio = mapper.Map<BarrioDtoOut>(masterRepository.Barrio.
                    FindByCondition(b => b.BarrioId == juntaDeVecinos.BarrioId).FirstOrDefault());

            return juntaDeVecinosDto;
        }
        public ServiceResult<IEnumerable<JuntaDeVecinosDtoOut>> GetAllJuntasDeVecinos()
        {
            try
            {
                var listJuntasDeVecinos = masterRepository.JuntaDeVecinos.GetAll();

                var listJuntasDeVecinosDto = new List<JuntaDeVecinosDtoOut>();

                foreach (var juntaDeVecinos in listJuntasDeVecinos)
                {
                    var juntaDeVecinosDto = MapToDto(juntaDeVecinos);
                    listJuntasDeVecinosDto.Add(juntaDeVecinosDto);
                }

                return ServiceResult<IEnumerable<JuntaDeVecinosDtoOut>>.ResultOk(listJuntasDeVecinosDto);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<JuntaDeVecinosDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<JuntaDeVecinosDtoOut> GetJuntaDeVecinosByJuntaDeVecinosId(int juntaDeVecinosId)
        {
            try
            {
                if (!juntaDeVecinosValidationService.IsExistingJuntaDeVecinosId(juntaDeVecinosId))
                    throw new ValidationException(JuntaDeVecinosMessageConstants.NotExistingJuntaDeVecinosId);

                var juntaDeVecinos = masterRepository.JuntaDeVecinos.FindByCondition(j =>
                    j.JuntaDeVecinosId == juntaDeVecinosId).FirstOrDefault();

                var juntaDeVecinosDto = mapper.Map<JuntaDeVecinosDtoOut>(juntaDeVecinos);

                return ServiceResult<JuntaDeVecinosDtoOut>.ResultOk(juntaDeVecinosDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<JuntaDeVecinosDtoOut>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<JuntaDeVecinosDtoOut>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<IEnumerable<JuntaDeVecinosDtoOut>> GetAllJuntasDeVecinosByBarrioId(int barrioId)
        {
            try
            {
                if (!barrioValidationService.IsExistingBarrioId(barrioId))
                    throw new ValidationException(BarrioMessageConstants.NotExistingBarrioId);

                var listJuntasDeVecinos = masterRepository.JuntaDeVecinos.FindByCondition(j =>
                    j.BarrioId == barrioId);

                if (listJuntasDeVecinos.Count() == 0)
                    throw new ValidationException(JuntaDeVecinosMessageConstants.NotExistingJuntaDeVecinosByCampos);

                var listJuntasDeVecinosDto = new List<JuntaDeVecinosDtoOut>();

                foreach (var juntaDeVecinos in listJuntasDeVecinos)
                {
                    var juntaDeVecinosDto = MapToDto(juntaDeVecinos);
                    listJuntasDeVecinosDto.Add(juntaDeVecinosDto);
                }

                return ServiceResult<IEnumerable<JuntaDeVecinosDtoOut>>.ResultOk(listJuntasDeVecinosDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IEnumerable<JuntaDeVecinosDtoOut>>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<JuntaDeVecinosDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }

        public ServiceResult<IEnumerable<JuntaDeVecinosDtoOut>> GetAllJuntasDeVecinosByDistritoMunicipalId(int distritoMunicipalId)
        {
            try
            {
                if (!distritoMunicipalValidationService.IsExistingDistritoMunicipalId(distritoMunicipalId))
                    throw new ValidationException(DistritoMunicipalMessageConstants.NotExistingDistritoMunicipalId);

                var listSecciones = masterRepository.Seccion.FindByCondition(s =>
                    s.DistritoMunicipalId == distritoMunicipalId);

                var listSectores = new List<Sector>();

                foreach (var seccion in listSecciones)
                {
                    var listSectoresTemp = masterRepository.Sector.FindByCondition(s =>
                        s.SeccionId == seccion.SeccionId);

                    foreach (var sector in listSectoresTemp)
                    {
                        listSectores.Add(sector);
                    }
                }

                var listBarrios = new List<Barrio>();

                foreach (var sector in listSectores)
                {
                    var listBarriosTemp = masterRepository.Barrio.FindByCondition(b =>
                        b.SectorId == sector.SectorId);

                    foreach (var barrio in listBarriosTemp)
                    {
                        listBarrios.Add(barrio);
                    }
                }

                var listJuntasDeVecinos = new List<JuntaDeVecinos>();

                foreach (var barrio in listBarrios)
                {
                    var listJuntasDeVecinosTemp = masterRepository.JuntaDeVecinos
                        .FindByCondition(j => j.BarrioId == barrio.BarrioId);

                    foreach (var juntaDeVecinos in listJuntasDeVecinosTemp)
                    {
                        listJuntasDeVecinos.Add(juntaDeVecinos);
                    }
                }

                if (listJuntasDeVecinos.Count() == 0)
                    throw new ValidationException(JuntaDeVecinosMessageConstants.NotExistingJuntaDeVecinosByCampos);

                var listJuntasDeVecinosDto = new List<JuntaDeVecinosDtoOut>();

                foreach (var juntaDeVecinos in listJuntasDeVecinos)
                {
                    var juntaDeVecinosDto = MapToDto(juntaDeVecinos);
                    listJuntasDeVecinosDto.Add(juntaDeVecinosDto);
                }

                return ServiceResult<IEnumerable<JuntaDeVecinosDtoOut>>.ResultOk(listJuntasDeVecinosDto);
            }
            catch (ValidationException e)
            {
                return ServiceResult<IEnumerable<JuntaDeVecinosDtoOut>>.ResultFailed(ResponseCode.Warning, e.Message);
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<JuntaDeVecinosDtoOut>>.ResultFailed(ResponseCode.Error, e.Message);
            }
        }
    }
}
