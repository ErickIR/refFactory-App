using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CitizenApp.Services.Interfaces
{
    interface IDeletable<T>
    {
        Task<bool> EliminarRegistroAsync(int itemId);
    }
}
