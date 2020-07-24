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

namespace CitizenApp.Services.Services
{
    public class IncidenciaService : BaseHttpClient
    {
        private List<Incidencia> Incidencias;
        private List<IncidenciaUsuario> Apoyos;
        private List<TipoIncidencia> TiposIncidencia;
        private List<StatusIncidencia> StatusIncidencias;
        public IncidenciaService()
        {

            TiposIncidencia = new List<TipoIncidencia>()
            {
                new TipoIncidencia() {TipoIncidenciaId= 1, Descripcion="Rechazado"}
            };
            StatusIncidencias = new List<StatusIncidencia>()
            {
                new StatusIncidencia() {StatusIncidenciaId=1, Descripcion="Salubridad"}
            };

            Incidencias = new List<Incidencia>();
        }

        public async Task RegistrarNuevaIncidenciaAsync(Incidencia incidencia)
        {

        }

        public async Task<bool> EliminarIncidenciaUsuarioAsync(int incidenciaUsuarioId)
        {
            Apoyos.RemoveAll(Incidencia => Incidencia.IncidenciaId == incidenciaUsuarioId);

            return await Task.FromResult(true);
        }

        public async Task<IncidenciaUsuario> RegistrarNuevoApoyoIncidenciaAsync(Incidencia incidencia, Usuario user)
        {
            var newApoyo = new IncidenciaUsuario()
            {
                IncidenciaId = incidencia.IncidenciaId,
                UsuarioId = user.UsuarioId
            };

            Apoyos.Add(newApoyo);

            return await Task.FromResult(newApoyo);
        }

        public async Task<IEnumerable<IncidenciaUsuario>> ObtenerRegistrosApoyoIncidencia(int incidenciaId)
        {
            var apoyosAIncidencia = Apoyos.FindAll(apoyo => apoyo.IncidenciaId == incidenciaId);

            return await Task.FromResult(apoyosAIncidencia);
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
            var incidencia = Incidencias.Find(cur => cur.IncidenciaId == itemId);

            return await Task.FromResult(incidencia);
        }

        public async Task<IEnumerable<TipoIncidencia>> ObtenerTiposDeIncidencia()
        {
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


    }
}
