using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CitizenApp.Services.Interfaces
{
    interface IEditable<T>
    {
        Task<bool> EditarRegistroAsync(T item);
    }
}
