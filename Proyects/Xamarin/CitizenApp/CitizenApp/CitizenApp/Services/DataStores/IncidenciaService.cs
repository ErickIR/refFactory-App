using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CitizenApp.Models;
using System.Linq;

namespace CitizenApp.Services.DataStores
{
    public class IncidenciaService 
    {
        List<Incidencia> Incidencias;
        List<IncidenciaUsuario> Apoyos;

        public IncidenciaService()
        {
            Incidencias = new List<Incidencia>()
            {
                new Incidencia { IncidenciaId = 1, Titulo = "Calle Rota 1", Descripcion = "La calle ta prendiaaaaaaa", EmpleadoId = 1, UsuarioId = 1, BarrioId = 1, StatusId = 1},
                new Incidencia { IncidenciaId = 2, Titulo = "Calle Rota 2", Descripcion = "La calle ta prendiaaaaaaa", EmpleadoId = 1, UsuarioId = 1, BarrioId = 1, StatusId = 1},
                new Incidencia { IncidenciaId = 3, Titulo = "Calle Rota 3", Descripcion = "La calle ta prendiaaaaaaa", EmpleadoId = 1, UsuarioId = 1, BarrioId = 1, StatusId = 1},
                new Incidencia { IncidenciaId = 4, Titulo = "Calle Rota 4", Descripcion = "La calle ta prendiaaaaaaa", EmpleadoId = 1, UsuarioId = 1, BarrioId = 1, StatusId = 1},
                new Incidencia { IncidenciaId = 5, Titulo = "Calle Rota 5", Descripcion = "La calle ta prendiaaaaaaa", EmpleadoId = 1, UsuarioId = 1, BarrioId = 1, StatusId = 1}
            };

            Apoyos = new List<IncidenciaUsuario>()
            {
                new IncidenciaUsuario { IncidenciaUsuarioId = 1, IncidenciaId = 1, UsuarioId = 1},
                new IncidenciaUsuario { IncidenciaUsuarioId = 2, IncidenciaId = 3, UsuarioId = 1},
                new IncidenciaUsuario { IncidenciaUsuarioId = 3, IncidenciaId = 5, UsuarioId = 1}
            };
        }

        public async Task<Incidencia> RegistrarNuevaIncidenciaAsync(Incidencia item)
        {
            Incidencias.Add(item);
            return await Task.FromResult(item);
        }

        public async Task<bool> EliminarIncidenciaUsuarioAsync(int incidenciaUsuarioId)
        {
            Apoyos.RemoveAll(Incidencia => Incidencia.IncidenciaId == incidenciaUsuarioId);

            return await Task.FromResult(true);
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
            return await Task.FromResult(Incidencias);
        }

        public async Task<Incidencia> ObtenerRegistroIncidenciaPorIdAsync(int itemId)
        {
            var incidencia = Incidencias.Find(cur => cur.IncidenciaId == itemId);

            return await Task.FromResult(incidencia);
        }
    }
}
