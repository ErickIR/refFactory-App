using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CitizenApp.Services
{
    interface IDataStore<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync();
        Task<T> CreateNewAsync();
        Task<T> EditAsync();
        Task<bool> DeleteAsync();
    }
}
