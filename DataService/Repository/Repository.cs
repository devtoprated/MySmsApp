using DataService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private TwilioAppContext _DbContext;
        public Repository(TwilioAppContext dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            try
            {
              var response = await _DbContext.Set<T>().AddAsync(entity);
               _DbContext.SaveChanges();
                return response.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task AddRange(List<T> entity)
        {
            try
            {
                await _DbContext.Set<T>().AddRangeAsync(entity);
                _DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
               
            }
        }

        public async Task Delete(T entity)
        {
            try
            {
                await Task.Run(() =>
                {
                    _DbContext.Set<T>().Remove(entity);
                    _DbContext.SaveChanges();
                });
            }
            catch (Exception ex)
            {
            }
        }

        public async Task DeleteRange(List<T> entity)
        {
            try
            {
                await Task.Run(() =>
                {
                    _DbContext.Set<T>().RemoveRange(entity);
                    _DbContext.SaveChanges();
                });
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                   var Data =   _DbContext.Set<T>().Where(predicate);
                    return Data.ToList();
                }
                else
                {
                    return await _DbContext.Set<T>().ToListAsync();
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                T Response = await _DbContext.Set<T>().FindAsync(id);
                return Response;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                await Task.Run(() =>
                {
                    _DbContext.Set<T>().Update(entity);
                    _DbContext.SaveChanges();
                });
            }
            catch (Exception ex)
            {
            }
        }

        public async Task UpdateRange(List<T> entity)
        {
            try
            {
                await Task.Run(() =>
                {
                    _DbContext.Set<T>().UpdateRange(entity);
                    _DbContext.SaveChanges();
                });
            }
            catch (Exception ex)
            {
            }
        }
    }
}
