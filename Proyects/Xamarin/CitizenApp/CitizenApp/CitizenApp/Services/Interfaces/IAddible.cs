using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CitizenApp.Services.Interfaces
{
    interface IAddible<T>
    {
        Task<T> RegistrarNuevoAsync(T item)
    }
}
