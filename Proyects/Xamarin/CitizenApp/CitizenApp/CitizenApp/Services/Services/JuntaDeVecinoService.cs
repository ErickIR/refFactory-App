using CitizenApp.Models;
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
            juntaDeVecinos = new List<JuntaDeVecinos>()
            {
                new JuntaDeVecinos { JuntaDeVecinosId = 1,  BarrioId = 1, Latitud = 41.40338, Longitud = 2.17403, Nombre = "Jose Contreras"  },
                new JuntaDeVecinos { JuntaDeVecinosId = 2,  BarrioId = 1, Latitud = 51.40338, Longitud = 2.17403, Nombre = "Miguel Contreras"},
                new JuntaDeVecinos { JuntaDeVecinosId = 3,  BarrioId = 1, Latitud = 61.40338, Longitud = 2.17403, Nombre = "Fernando Contreras" },
                new JuntaDeVecinos { JuntaDeVecinosId = 4,  BarrioId = 1, Latitud = 31.40338, Longitud = 2.17403, Nombre = "Juelia Contreras"  },
                new JuntaDeVecinos { JuntaDeVecinosId = 5,  BarrioId = 1, Latitud = 21.40338, Longitud = 2.17403, Nombre = "Maria Contreras" },
            };
            roles = new List<Rol>()
            {
                new Rol { RolId = 1, Descripcion = "Presidente"},
                new Rol { RolId = 2, Descripcion = "Administrador"},
                new Rol { RolId = 3, Descripcion = "Tesorero"},
                new Rol { RolId = 4, Descripcion = "Asistente"}

            };
            integrantesJdVs = new List<IntegranteJdV>()
            {
                new IntegranteJdV {IntegranteId = 1, JuntaDeVecinosId = 1, UsuarioId = 1, RoldId = 1},
                new IntegranteJdV {IntegranteId = 2, JuntaDeVecinosId = 1, UsuarioId = 1, RoldId = 2},
                new IntegranteJdV {IntegranteId = 3, JuntaDeVecinosId = 1, UsuarioId = 1, RoldId = 3},
                new IntegranteJdV {IntegranteId = 4, JuntaDeVecinosId = 1, UsuarioId = 1, RoldId = 4},
                new IntegranteJdV {IntegranteId = 5, JuntaDeVecinosId = 2, UsuarioId = 1, RoldId = 1},
                new IntegranteJdV {IntegranteId = 6, JuntaDeVecinosId = 2, UsuarioId = 1, RoldId = 2},
                new IntegranteJdV {IntegranteId = 7, JuntaDeVecinosId = 2, UsuarioId = 1, RoldId = 3},
                new IntegranteJdV {IntegranteId = 8, JuntaDeVecinosId = 2, UsuarioId = 1, RoldId = 4},
                new IntegranteJdV {IntegranteId = 8, JuntaDeVecinosId = 3, UsuarioId = 1, RoldId = 1}

            };

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
           
            return await Task.FromResult(juntaDeVecinos);
        }

        public async Task<IEnumerable<IntegranteJdV>> ObtenerIntegrantesporJuntaDeVecinoID(int juntaDeVecinoID)
        {
            List<IntegranteJdV> listaIntegrantes = new List<IntegranteJdV>();

            var integrantesJDVList = integrantesJdVs.FindAll(x => x.JuntaDeVecinosId == juntaDeVecinoID);
            foreach (var item in integrantesJDVList)
            {
                IntegranteJdV integranteJdV = new IntegranteJdV();

                integranteJdV.JuntaDeVecinosId = item.JuntaDeVecinosId;
                integranteJdV.IntegranteId = item.IntegranteId;
                integranteJdV.UsuarioId = item.UsuarioId;
                integranteJdV.RoldId = item.RoldId;
                integranteJdV.rol = ObtenerRoldeUsuarioPorRolId(item.RoldId);
                integranteJdV.usuario = ObtenerUsuarioPorUserId(item.IntegranteId);
                listaIntegrantes.Add(integranteJdV);
                integranteJdV = null;

            }
            return await Task.FromResult(listaIntegrantes);
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