using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompanyBranchCore.Interfaces
{
    public interface IGenricRepository<T> where T : class
    {
        Task<(IEnumerable<T> Items, int TotalCount)> GetAllAsync(int pageSize = 10, int pageNumber = 1, Expression<Func<T, bool>>? filter = null, string? orderBy = null
                );
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
  
       
        Task<(IEnumerable<T> Items, int TotalCount)> GetAllWithIncludeAsync(
         Expression<Func<T, bool>>? filter = null,
         int pageNumber = 1,
         int pageSize = 10,
         params Expression<Func<T, object>>[] includes);

    }
}
