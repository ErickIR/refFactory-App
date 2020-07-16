using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CitizenApp.Models;
using System.Linq;

namespace CitizenApp.Services.DataStores
{
    class IncidenciaService : IDataStore<Incidencia>
    {
        List<Incidencia> Incidencias;

        public IncidenciaService()
        {
            Incidencias = new List<Incidencia>()
            {
                new Incidencia { IncidenciaId = 1, Titulo = "Calle Rota 1", Descripcion = "La calle ta prendiaaaaaaa", EmpleadoId = 1, UsuarioId = 2, BarrioId = 1, StatusId = 1},
                new Incidencia { IncidenciaId = 2, Titulo = "Calle Rota 2", Descripcion = "La calle ta prendiaaaaaaa", EmpleadoId = 1, UsuarioId = 2, BarrioId = 1, StatusId = 1},
                new Incidencia { IncidenciaId = 3, Titulo = "Calle Rota 3", Descripcion = "La calle ta prendiaaaaaaa", EmpleadoId = 1, UsuarioId = 2, BarrioId = 1, StatusId = 1},
                new Incidencia { IncidenciaId = 4, Titulo = "Calle Rota 4", Descripcion = "La calle ta prendiaaaaaaa", EmpleadoId = 1, UsuarioId = 2, BarrioId = 1, StatusId = 1},
                new Incidencia { IncidenciaId = 5, Titulo = "Calle Rota 5", Descripcion = "La calle ta prendiaaaaaaa", EmpleadoId = 1, UsuarioId = 2, BarrioId = 1, StatusId = 1}
            };
        }

        public async Task<Incidencia> RegistrarNuevoAsync(Incidencia item)
        {
            Incidencias.Add(item);
            return await Task.FromResult(item);
        }

        public async Task<bool> EliminarRegistroAsync(int itemId)
        {
            Incidencias.RemoveAll(Incidencia => Incidencia.IncidenciaId == itemId);

            return await Task.FromResult(true);
        }

        public async Task<bool> EditarRegistroAsync(Incidencia item)
        {
            var oldItem = Incidencias.Where((Incidencia arg) => arg.IncidenciaId == item.IncidenciaId).FirstOrDefault();
            Incidencias.Remove(oldItem);
            Incidencias.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Incidencia>> ObtenerTodosRegistrosAsync()
        {
            return await Task.FromResult(Incidencias);
        }

        public async Task<Incidencia> ObtenerRegistroPorIdAsync(int itemId)
        {
            var incidencia = Incidencias.Find(cur => cur.IncidenciaId == itemId);

            return await Task.FromResult(incidencia);
        }
    }
}
