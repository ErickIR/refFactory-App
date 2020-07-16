using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CitizenApp.Services
{
    interface IDataStore<T>
    {
        Task<IEnumerable<T>> ObtenerTodosRegistrosAsync();
        Task<T> ObtenerRegistroPorIdAsync(int itemId);
        Task<T> RegistrarNuevoAsync(T item);
        Task<bool> EditarRegistroAsync(T item);
        Task<bool> EliminarRegistroAsync(int itemId);
    }
}
