using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CitizenApp.Services
{
    public abstract class IDataStore<T>
    {
        public abstract Task<IEnumerable<T>> ObtenerTodosRegistrosAsync();
        public abstract Task<T> ObtenerRegistroPorIdAsync(int itemId);
        public abstract Task<T> RegistrarNuevoAsync(T item);
        public abstract Task<bool> EditarRegistroAsync(T item);
        public abstract Task<bool> EliminarRegistroAsync(int itemId);
    }
}
