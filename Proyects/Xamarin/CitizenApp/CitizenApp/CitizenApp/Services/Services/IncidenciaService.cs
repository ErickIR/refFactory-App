using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CitizenApp.Models;
using System.Linq;

namespace CitizenApp.Services.Services
{
    public class IncidenciaService 
    {
        List<Incidencia> Incidencias;
        List<IncidenciaUsuario> Apoyos;
        List<TipoIncidencia> TiposIncidencia;
        List<StatusIncidencia> StatusIncidencias;
        int nextIncidenciaIdx = 6;
        int nextApoyoIdx = 4;
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

            TiposIncidencia = new List<TipoIncidencia>()
            {
                new TipoIncidencia { TipoIncidenciaId = 1, Descripcion = "Salubridad" },
                new TipoIncidencia { TipoIncidenciaId = 2, Descripcion = "Mantenimiento" },
                new TipoIncidencia { TipoIncidenciaId = 3, Descripcion = "Comunicacion"}
            };

            StatusIncidencias = new List<StatusIncidencia>()
            {
                new StatusIncidencia { StatusIncidenciaId = 1, Descripcion = "En Proceso"},
                new StatusIncidencia { StatusIncidenciaId = 2, Descripcion = "Completada"}
            };
        }

        public async Task<Incidencia> RegistrarNuevaIncidenciaAsync(Incidencia item)
        {
            item.IncidenciaId = nextIncidenciaIdx;

            Incidencias.Add(item);
            nextIncidenciaIdx++;

            return await Task.FromResult(item);
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
                IncidenciaUsuarioId = nextApoyoIdx++,
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
            return await Task.FromResult(Incidencias);
        }

        public async Task<Incidencia> ObtenerRegistroIncidenciaPorIdAsync(int itemId)
        {
            var incidencia = Incidencias.Find(cur => cur.IncidenciaId == itemId);

            return await Task.FromResult(incidencia);
        }

        public async Task<IEnumerable<TipoIncidencia>> ObtenerTiposDeIncidencia()
        {
            return await Task.FromResult(TiposIncidencia);
        }

        public async Task<IEnumerable<StatusIncidencia>> ObtenerEstadosDeIncidencia()
        {
            return await Task.FromResult(StatusIncidencias);
        }

        public async Task<IEnumerable<Incidencia>> ObtenerIncidenciasPorEstadoAsync(int statusId)
        {
            var incidencias = Incidencias.FindAll(inc => inc.StatusId == statusId);

            return await Task.FromResult(incidencias);
        }

        public async Task<IEnumerable<Incidencia>> ObtenerIncidenciasPorTipoAsync(int tipoId)
        {
            var incidencias = Incidencias.FindAll(inc => inc.TipoIncidenciaId == tipoId);

            return await Task.FromResult(incidencias);
        }

        public async Task<IEnumerable<Incidencia>> ObtenerMisIncidenciasAsync(int userId)
        {
            var incidencias = Incidencias.FindAll(inc => inc.UsuarioId == userId);

            return await Task.FromResult(incidencias);
        }
    }
}
