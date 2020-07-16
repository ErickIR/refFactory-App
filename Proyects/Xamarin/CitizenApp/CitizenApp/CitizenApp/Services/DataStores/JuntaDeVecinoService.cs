using CitizenApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CitizenApp.Services.DataStores
{
    class JuntaDeVecinoService 
    {
        List<JuntaDeVecinos> juntaDeVecinos;
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
        }
        public async Task<JuntaDeVecinos> ObtenerJuntaDeVecinoPorBarrioID(int barrioId)
        {
            var juntaDeVecino = juntaDeVecinos.Find(x => x.BarrioId == barrioId);
            return await Task.FromResult(juntaDeVecino);
        }
        public async Task<List<JuntaDeVecinos>> ObtenerJuntaDeVecinoPorMunicipioID(int municipioID)
        {
            
            return await Task.FromResult(juntaDeVecino);
        }




    }
}
