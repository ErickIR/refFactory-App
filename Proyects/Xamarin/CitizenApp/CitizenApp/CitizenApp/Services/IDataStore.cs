using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CitizenApp.Services
{
    interface IDataStore<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int itemId);
        Task<T> AddNewAsync(T item);
        Task<bool> EditAsync(T item);
        Task<bool> DeleteAsync(int itemId);
    }
}
