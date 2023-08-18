using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repository
{
    public interface IRepository <T> where T : class
    {
        Task<T> AddAsync(T entity); 
        Task UpdateAsync(T entity); 
        Task Delete(T entity); 
        Task AddRange(List<T> entity); 
        Task DeleteRange(List<T> entity); 
        Task UpdateRange(List<T> entity); 
        Task<T> GetByIdAsync(int id);   
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);   
    }
}
