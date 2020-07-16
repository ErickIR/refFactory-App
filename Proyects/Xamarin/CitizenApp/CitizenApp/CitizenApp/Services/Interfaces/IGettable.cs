using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CitizenApp.Services.Interfaces
{
    interface IGettable<T>
    {
        Task<IEnumerable<T>> ObtenerTodosRegistrosAsync();
        Task<T> ObtenerRegistroPorIdAsync(int itemId);
    }
}
