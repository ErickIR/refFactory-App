using CitizenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenApp.Common;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace CitizenApp.Services.DataStores
{
    public class LocalidadService : BaseHttpClient
    {
        List<Region> regiones;
        List<Provincia> provincias;
        List<Municipio> municipios;
        List<DistritoMunicipal> distritoMunicipales;
        List<Seccion> secciones;
        List<Sector> sectores;
        List<Barrio> barrios;

        public LocalidadService() { }

        public async Task<List<Barrio>> ObtenerBarriosPorSectorIDAsync(int sectorId)
        {
            var result = new List<Barrio>();
            try
            {
                var response = await Instance.GetAsync(ApiUrls.Barrio);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<HttpResult<Barrio>>(responseString);
                    if (model.ErrorCode == ResponseCode.Ok)
                        result = (List<Barrio>)model.Result;
                    else
                        throw new Exception(model.ErrorMessage);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<List<Sector>> ObtenerSectoresPorSeccionIDAsync(int seccionId)
        {
            var sectoresResult = sectores.FindAll(x => x.SeccionId == seccionId);
            return await Task.FromResult(sectoresResult);
        }

        public async Task<List<Seccion>> ObtenerSeccionesPorDistritoMunicipalesIDAsync(int distritoMunicipalesId)
        {
            var seccionesResult = secciones.FindAll(x => x.DistritoMunicipalId == distritoMunicipalesId);
            return await Task.FromResult(seccionesResult);
        }

        public async Task<List<DistritoMunicipal>> ObtenerDistritoMunicipalesPorMunicipioIDAsync(int municipioId)
        {
            var distritoMunicipalesResult = distritoMunicipales.FindAll(x => x.MunicipioId == municipioId);
            return await Task.FromResult(distritoMunicipalesResult);
        }

        public async Task<List<Municipio>> ObtenerMunicipiosPorProvinciaIDAsync(int provinciaId)
        {
            var municipiosResult = municipios.FindAll(x => x.ProvinciaId == provinciaId);
            return await Task.FromResult(municipiosResult);
        }

        public async Task<List<Provincia>> ObtenerProvinciasPorRegionIDAsync(int regionId)
        {
            var provinciasResult = provincias.FindAll(x => x.RegionId == regionId);
            return await Task.FromResult(provinciasResult);
        }

        public async Task<List<Region>> ObtenerRegionesAsync()
        {

            return await Task.FromResult(regiones);
        }

        public async Task<List<Barrio>> ObtenerBarriosPorDistritosMunicipalesIDAsync(int distritosMunicipalesId)
        {
            var listaSecciones = await ObtenerSeccionesPorDistritoMunicipalesIDAsync(distritosMunicipalesId);
            List<Sector> listSectores = new List<Sector>();
            List<Barrio> listBarrios = new List<Barrio>();
            foreach (var seccion in listaSecciones)
            {

                listSectores = listSectores.Concat(await ObtenerSectoresPorSeccionIDAsync(seccion.SeccionId)).ToList();

            }

            foreach (var sector in listSectores)
            {
                listBarrios = listBarrios.Concat(await ObtenerBarriosPorSectorIDAsync(sector.SectorId)).ToList();
            }


            return await Task.FromResult(listBarrios);
        }

        public async Task<IEnumerable<Region>> ObtenerRegiones()
        {
            return await Task.FromResult(regiones);
        }
        public async Task<IEnumerable<Provincia>> ObtenerProvincias()
        {
            return await Task.FromResult(provincias);
        }
        public async Task<IEnumerable<Municipio>> ObtenerMunicipios()
        {
            var result = new List<Municipio>();
            try
            {
                var response = await Instance.GetAsync(ApiUrls.Municipio);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<HttpResult<Municipio>>(responseString);
                    if (model.ErrorCode == ResponseCode.Ok)
                        result = (List<Municipio>)model.Result;
                    else
                        throw new Exception(model.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public async Task<IEnumerable<DistritoMunicipal>> ObtenerDistritoMunicipales()
        {
            var result = new List<DistritoMunicipal>();
            try
            {
                var response = await Instance.GetAsync(ApiUrls.DistritoMunicipal);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<HttpResult<DistritoMunicipal>>(responseString);
                    if (model.ErrorCode == ResponseCode.Ok)
                        result = (List<DistritoMunicipal>)model.Result;
                    else
                        throw new Exception(model.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public async Task<IEnumerable<Seccion>> ObtenerSecciones()
        {
            return await Task.FromResult(secciones);
        }
        public async Task<IEnumerable<Sector>> ObtenerSectores()
        {
            return await Task.FromResult(sectores);
        }
        public async Task<IEnumerable<Barrio>> ObtenerBarrios()
        {
            return await Task.FromResult(barrios);
        }
       

    }
}