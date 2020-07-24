using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CitizenApp.Models;
using System.Linq;
using System.Net.Http;
using CitizenApp.Common;
using Newtonsoft.Json;
using Org.Apache.Http.Protocol;
using Android.Media;
using RestSharp;

namespace CitizenApp.Services.Services
{
    public class IncidenciaService : BaseHttpClient
    {
        private List<Incidencia> Incidencias;
        private List<TipoIncidencia> TiposIncidencia;
        private List<StatusIncidencia> StatusIncidencias;
        public IncidenciaService()
        {

            TiposIncidencia = new List<TipoIncidencia>();

            StatusIncidencias = new List<StatusIncidencia>();

            Incidencias = new List<Incidencia>();
        }

        public void PostTowardUrl( IncidenciaPost obj)
        {
            var client = new RestClient("http://192.168.0.100:44346/api/incidencia/post-incidencia");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json; charset=utf-8");
            request.AddHeader("server", "Microsoft-IIS/10.0");
            request.AddJsonBody(obj);
            IRestResponse response = client.Execute(request);
        }

        public async Task<bool> RegistrarNuevaIncidenciaAsync(IncidenciaPost incidencia)
        {
            try
            {
                var json = JsonConvert.SerializeObject(incidencia);
                var stringContent = new StringContent(
                    json,
                    System.Text.Encoding.UTF8,
                    "application/json"
                );
                var response = await Instance.PostAsync("incidencia/post-incidencia", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var httpResult = JsonConvert.DeserializeObject<HttpResult<bool>>(content);
                    if (httpResult.ErrorCode == ResponseCode.Ok)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception(httpResult.ErrorMessage);
                    }
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //public async Task<bool> EliminarIncidenciaUsuarioAsync(int incidenciaUsuarioId)
        //{
        //    Apoyos.RemoveAll(Incidencia => Incidencia.IncidenciaId == incidenciaUsuarioId);

        //    return await Task.FromResult(true);
        //}

        public async Task<bool> RegistrarNuevoApoyoIncidenciaAsync(IncidenciaUsuario apoyo)
        {
            try
            {
                var json = JsonConvert.SerializeObject(apoyo);
                var stringContent = new StringContent(
                    json,
                    System.Text.Encoding.UTF8,
                    "application/json"
                );
                var response = await Instance.PostAsync("incidencia-usuario/post-apoyo", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var httpResult = JsonConvert.DeserializeObject<HttpResult<bool>>(content);
                    if (httpResult.ErrorCode == ResponseCode.Ok)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception(httpResult.ErrorMessage);
                    }
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        public async Task<bool> EditarRegistroIncidenciaAsync(Incidencia item)
        {
            var oldItem = Incidencias.Where((Incidencia arg) => arg.IncidenciaId == item.IncidenciaId).FirstOrDefault();
            Incidencias.Remove(oldItem);
            Incidencias.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Incidencia>> ObtenerTodosRegistrosIncidenciaAsync()
        {
            Incidencias.Clear();
            try
            {
                var response = await Instance.GetAsync($"{ApiUrls.IncidenciaBarrio}/4");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var httpResult = JsonConvert.DeserializeObject<HttpResult<IEnumerable<Incidencia>>>(content);
                    if(httpResult.ErrorCode == ResponseCode.Ok)
                    {
                        foreach (var item in httpResult.Result)
                            Incidencias.Add(item);
                    }
                    else
                    {
                        throw new Exception(httpResult.ErrorMessage);
                    }
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return Incidencias;
        }
         
        public async Task<Incidencia> ObtenerRegistroIncidenciaPorIdAsync(int itemId)
        {
            var incidencia = new Incidencia();
            try
            {
                var response = await Instance.GetAsync($"incidencia/{itemId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var httpResult = JsonConvert.DeserializeObject<HttpResult<Incidencia>>(content);
                    if (httpResult.ErrorCode == ResponseCode.Ok)
                    {
                        incidencia = httpResult.Result;
                    }
                    else
                    {
                        throw new Exception(httpResult.ErrorMessage);
                    }
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return incidencia;
        }

        public async Task<IEnumerable<TipoIncidencia>> ObtenerTiposDeIncidencia()
        {
            TiposIncidencia.Clear();
            try
            {
                var response = await Instance.GetAsync($"tipo-incidencia/");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var httpResult = JsonConvert.DeserializeObject<HttpResult<IEnumerable<TipoIncidencia>>>(content);
                    if (httpResult.ErrorCode == ResponseCode.Ok)
                    {
                        foreach (var item in httpResult.Result)
                            TiposIncidencia.Add(item);
                    }
                    else
                    {
                        throw new Exception(httpResult.ErrorMessage);
                    }
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return TiposIncidencia;
        }

        public async Task<IEnumerable<StatusIncidencia>> ObtenerEstadosDeIncidencia()
        {
            StatusIncidencias.Clear();
            try
            {
                var response = await Instance.GetAsync($"status-incidencia/");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var httpResult = JsonConvert.DeserializeObject<HttpResult<IEnumerable<StatusIncidencia>>>(content);
                    if (httpResult.ErrorCode == ResponseCode.Ok)
                    {
                        foreach (var item in httpResult.Result)
                            StatusIncidencias.Add(item);
                    }
                    else
                    {
                        throw new Exception(httpResult.ErrorMessage);
                    }
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return StatusIncidencias;
        }

        public async Task<IEnumerable<Incidencia>> ObtenerIncidenciasPorEstadoAsync(int statusId)
        {
            var incidencias = Incidencias.FindAll(inc => inc.Status.StatusIncidenciaId == statusId);

            return await Task.FromResult(incidencias);
        }

        public async Task<IEnumerable<Incidencia>> ObtenerIncidenciasPorTipoAsync(int tipoId)
        {
            var incidencias = Incidencias.FindAll(inc => inc.TipoIncidencia.TipoIncidenciaId == tipoId);

            return await Task.FromResult(incidencias);
        }

        public async Task<IEnumerable<Incidencia>> ObtenerIncidenciasPorPalabraAsync(string search)
        {
            var incidencias = Incidencias.FindAll(inc => inc.Titulo.Contains(search) || inc.Descripcion.Contains(search));

            return await Task.FromResult(incidencias);
        }
        
        public async Task<IEnumerable<Incidencia>> ObtenerMisIncidenciasAsync(int userId)
        {
            var incidencias = Incidencias.FindAll(inc => inc.Usuario.UsuarioId == userId);

            return await Task.FromResult(incidencias);
        }

        public async Task<IEnumerable<Incidencia>> OrdenarMasVotadas()
        {
            var incidencias = Incidencias.OrderBy(inc => inc.Apoyos);
            return await Task.FromResult(incidencias);
        }
    }
}
