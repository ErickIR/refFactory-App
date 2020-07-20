using CitizenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenApp.Services.DataStores
{
    class JuntaDeVecinoService
    {
        List<JuntaDeVecinos> juntaDeVecinos;
        List<IntegranteJdV> integrantesJdVs;
        List<Rol> roles;
        public JuntaDeVecinoService()
        {
            juntaDeVecinos = new List<JuntaDeVecinos>()
            {
                new JuntaDeVecinos { JuntaDeVecinosId = 1,  BarrioId = 1, Latitud = 41.40338, Longitud = 2.17403, Nombre = "Jose Contreras"  },
                new JuntaDeVecinos { JuntaDeVecinosId = 2,  BarrioId = 1, Latitud = 51.40338, Longitud = 2.17403, Nombre = "Miguel Contreras"  },
                new JuntaDeVecinos { JuntaDeVecinosId = 3,  BarrioId = 1, Latitud = 61.40338, Longitud = 2.17403, Nombre = "Fernando Contreras"  },
                new JuntaDeVecinos { JuntaDeVecinosId = 4,  BarrioId = 1, Latitud = 31.40338, Longitud = 2.17403, Nombre = "Juelia Contreras"  },
                new JuntaDeVecinos { JuntaDeVecinosId = 5,  BarrioId = 1, Latitud = 21.40338, Longitud = 2.17403, Nombre = "Maria Contreras"  },
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
                new IntegranteJdV {IntegranteId = 1, JuntaDeVecinosId = 1, UsuarioId = 1, RoldId = 1}
            };
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