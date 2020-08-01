using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using BoatRentSolution.Data.Core;

namespace BoatRentSolution.Repository.Common
{
    /// <summary>
    /// Generic Repository Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T>, IDisposable where T : Entity<long>, new()
    {
        public readonly BoatRentContext _context;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="context"></param>
        public Repository(BoatRentContext context)
        {
            _context = context;
        }
        public Repository()
        { }


        /// <summary>
        /// GetAllItem method
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAllItem(int pageSize, int pageNumber, string name)
        {
            return _context.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

      

        

        /// <summary>
        /// Syncronous methos to add item to database of context
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddItem(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        #region "Async Methods"
        /// <summary>
        /// GetItemAsync method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<T> GetItemAsync(long id)
        {
            Task<T> item = Task.Factory.StartNew(() =>
            {
                return _context.Set<T>().FirstOrDefault(x => x.Id == id);
            });
            return item;
        }

        /// <summary>
        /// GetAllAsync method
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAllAsync()
        {
            List<T> result = _context.Set<T>().AsNoTracking().ToList<T>();
            return result;
        }

        /// <summary>
        /// GetAllAsync method
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllAsyn()
        {
            List<T> result = await _context.Set<T>().ToListAsync<T>();
            return result;
        }

        /// <summary>
        /// AddItemAsync method
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> AddItemAsync(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> AddItemsAsync(IEnumerable<T> entities)
        {
            try
            {
                foreach (T entity in entities)
                {
                    _context.Set<T>().Add(entity);
                }
                await _context.SaveChangesAsync();
                return entities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> UpdateItemsAsync(IEnumerable<T> entities)
        {
            try
            {
                foreach (T entity in entities)
                {
                    T existedEntity = GetItemAsync(entity.Id).Result;

                    if (existedEntity != null)
                    {
                        _context.Entry(existedEntity).State = EntityState.Detached;
                        _context.Set<T>().Update(entity);
                    }
                }
                await _context.SaveChangesAsync();
                return entities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> DeleteItemsAsync(IEnumerable<T> entities)
        {
            try
            {
                foreach (T entity in entities)
                {
                    T existedEntity = GetItemAsync(entity.Id).Result;

                    if (existedEntity != null)
                    {
                        _context.Entry(existedEntity).State = EntityState.Detached;
                        _context.Set<T>().Remove(entity);
                    }
                }
                await _context.SaveChangesAsync();
                return entities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// UpdateItemAsync method
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> UpdateItemAsync(T entity)
        {
            try
            {
                var existedEntity = GetItemAsync(entity.Id).Result;

                if (existedEntity != null)
                {
                    _context.Entry(existedEntity).State = EntityState.Detached;
                    _context.Set<T>().Update(entity);
                    await _context.SaveChangesAsync();
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// DeleteItemAsync method
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> DeleteItemAsync(T entity)
        {
            T existedEntity = GetItemAsync(entity.Id).Result;

            if (existedEntity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            return entity;
        }
        #endregion "Async Methods"
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
