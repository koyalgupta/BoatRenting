using BoatRentSolution.Repository.Common;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BoatRentSolution.Service.Common
{
    public class Services<T> : IServices<T> where T : class, new()
    {
        public IRepository<T> _repository;

        public Services(IRepository<T> repository)
        {
            this._repository = repository;
        }

        public Task<T> GetItemAsync(long id)
        {
            return _repository.GetItemAsync(id);
        }

        public async Task<T> UpdateItemAsync(T entity)
        {
            return await _repository.UpdateItemAsync(entity);
        }

        public async Task<T> AddItemAsync(T entity)
        {
            return await _repository.AddItemAsync(entity);
        }

        public Task<T> DeleteItemAsync(T entity)
        {
            return _repository.DeleteItemAsync(entity);
        }

        public IEnumerable<T> GetAllItem(int pageSize, int pageNumber, string name)
        {
            return _repository.GetAllItem(pageSize, pageNumber, name);
        }

        public IEnumerable<T> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }


        public async Task<IEnumerable<T>> GetAllAsyn()
        {
            return await _repository.GetAllAsyn();
        }

        public Task<IEnumerable<T>> AddItemsAsync(IEnumerable<T> entities)
        {
            return _repository.AddItemsAsync(entities);
        }

        public Task<IEnumerable<T>> UpdateItemsAsync(IEnumerable<T> entities)
        {
            return _repository.UpdateItemsAsync(entities);
        }

        public Task<IEnumerable<T>> DeleteItemsAsync(IEnumerable<T> entities)
        {
            return _repository.DeleteItemsAsync(entities);
        }
        
    }
}
