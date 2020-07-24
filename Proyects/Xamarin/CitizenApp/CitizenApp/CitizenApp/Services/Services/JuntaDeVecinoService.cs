using CitizenApp.Common;
using CitizenApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CitizenApp.Services.DataStores
{
    public class JuntaDeVecinoService : BaseHttpClient
    {
        List<JuntaDeVecinos> juntaDeVecinos;
        List<IntegranteJdV> integrantesJdVs;
        List<Rol> roles;
        List<Usuario> usuarios;
      
        public JuntaDeVecinoService()
        {
            juntaDeVecinos = new List<JuntaDeVecinos>();
            roles = new List<Rol>();

            usuarios = new List<Usuario>()
            {
                new Usuario{ Nombres = "Fernando Enmanuel", Apellidos = "Hernandez Perez", BarrioId =1, Documento = "40236737728", Email = "fehepe11@gmail.com", TipoDocumentoId = 1, UsuarioId = 1, TipoUsuarioId = 2},
                new Usuario{ Nombres = "Marcos Elias", Apellidos = "Perez Caba", BarrioId =1, Documento = "40236737718", Email = "marcoselis@gmail.com", TipoDocumentoId = 1, UsuarioId = 2, TipoUsuarioId = 2},
                new Usuario{ Nombres = "Erick Manuel", Apellidos = "Rodriguez", BarrioId =1, Documento = "40236737738", Email = "fehepe11@gmail.com", TipoDocumentoId = 1, UsuarioId = 3, TipoUsuarioId = 2},
                new Usuario{ Nombres = "Richard", Apellidos = "Mariano", BarrioId =1, Documento = "40236737748", Email = "fehepe11@gmail.com", TipoDocumentoId = 1, UsuarioId = 4, TipoUsuarioId = 2},
                new Usuario{ Nombres = "Charline", Apellidos = "Mateo", BarrioId =1, Documento = "40236737758", Email = "fehepe11@gmail.com", TipoDocumentoId = 1, UsuarioId = 5, TipoUsuarioId = 2},
                new Usuario{ Nombres = "Alex Rafael", Apellidos = "Hernandez Perez", BarrioId =1, Documento = "40236737768", Email = "fehepe11@gmail.com", TipoDocumentoId = 1, UsuarioId = 6, TipoUsuarioId = 2},
                new Usuario{ Nombres = "Maria", Apellidos = "Hernandez Perez", BarrioId =1, Documento = "40236737778", Email = "fehepe11@gmail.com", TipoDocumentoId = 1, UsuarioId = 7, TipoUsuarioId = 2},
                new Usuario{ Nombres = "Julia Maria", Apellidos = "Hernandez Perez", BarrioId =1, Documento = "40236737888", Email = "fehepe11@gmail.com", TipoDocumentoId = 1, UsuarioId = 8, TipoUsuarioId = 2},
                new Usuario{ Nombres = "Daniela", Apellidos = "Hernandez Perez", BarrioId =1, Documento = "40236737798", Email = "fehepe11@gmail.com", TipoDocumentoId = 1, UsuarioId = 9, TipoUsuarioId = 2},
                
            };
        }

        public async Task<IEnumerable<JuntaDeVecinos>> ObtenerJuntaDeVecinos()
        {
            juntaDeVecinos.Clear();
            try
            {
                var response = await Instance.GetAsync($"junta-de-vecinos/barrio/4");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var httpResult = JsonConvert.DeserializeObject<HttpResult<IEnumerable<JuntaDeVecinos>>>(content);
                    if (httpResult.ErrorCode == ResponseCode.Ok)
                    {
                        foreach (var item in httpResult.Result)
                            juntaDeVecinos.Add(item);
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
            return juntaDeVecinos;
        }

        public async Task<IEnumerable<IntegranteJdV>> ObtenerIntegrantesporJuntaDeVecinoID(int juntaDeVecinoID)
        {
            List<IntegranteJdV> listaIntegrantes = new List<IntegranteJdV>();
            try
            {
                var response = await Instance.GetAsync($"/api/integrante-jdv/junta-de-vecinos/{juntaDeVecinoID}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var httpResult = JsonConvert.DeserializeObject<HttpResult<IEnumerable<IntegranteJdV>>>(content);
                    if (httpResult.ErrorCode == ResponseCode.Ok)
                    {
                        foreach (var item in httpResult.Result)
                            listaIntegrantes.Add(item);
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
            return listaIntegrantes;
        }
        private Usuario ObtenerUsuarioPorUserId(int UserId)
        {
            var usuario = usuarios.Find(x => x.UsuarioId == UserId);
            
            return usuario;
        }
        public Rol ObtenerRoldeUsuarioPorRolId(int rolID)
        {
            var rol = roles.Find(x => x.RolId == rolID);

            return rol;
        }

        public async Task<JuntaDeVecinos> ObtenerJuntaDeVecinoPorBarrioID(int barrioId)
        {
            var juntaDeVecino = juntaDeVecinos.Find(x => x.BarrioId == barrioId);
            return await Task.FromResult(juntaDeVecino);
        }
        public async Task<List<JuntaDeVecinos>> ObtenerJuntaDeVecinoPorDistritoMunicipal(int distritoMunicipalId)
        {
            LocalidadService localidadService = new LocalidadService();
            var listBarrios = await localidadService.ObtenerBarriosPorDistritosMunicipalesIDAsync(distritoMunicipalId);
            List<JuntaDeVecinos> listJuntaDeVecinos = new List<JuntaDeVecinos>();

            foreach (var barrio in listBarrios)
            {
                listJuntaDeVecinos = listJuntaDeVecinos.Concat(juntaDeVecinos.FindAll(x => x.BarrioId == barrio.BarrioId)).ToList();
            }

            return await Task.FromResult(listJuntaDeVecinos);
        }
        public async Task<List<IntegranteJdV>> ObtenerIntengrantesporJuntaDeVecinoID(int juntaDeVecinoId)
        {
            var listIntegrantesJdVs = integrantesJdVs.FindAll(x => x.JuntaDeVecinosId == juntaDeVecinoId);
            return await Task.FromResult(listIntegrantesJdVs);
        }

        public async Task<Rol> ObtenerRoldeIntegranteId(int IntegranteId)
        {
            var rol = roles.Find(x => x.RolId == IntegranteId);
            return await Task.FromResult(rol);
        }




    }
}