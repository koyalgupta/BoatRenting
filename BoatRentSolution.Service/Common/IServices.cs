using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BoatRentSolution.Service.Common
{
    public interface IServices<T> where T : new()
    {
        IEnumerable<T> GetAllItem(int pageSize, int pageNumber, string name);
        IEnumerable<T> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsyn();
        Task<T> GetItemAsync(long id);
        Task<T> AddItemAsync(T entity);
        Task<T> UpdateItemAsync(T entity);
        Task<T> DeleteItemAsync(T entity);
        Task<IEnumerable<T>> AddItemsAsync(IEnumerable<T> entities);
        Task<IEnumerable<T>> UpdateItemsAsync(IEnumerable<T> entities);
        Task<IEnumerable<T>> DeleteItemsAsync(IEnumerable<T> entities);
    }
}
