using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vish_Tech_Ecom.Core.Entities;

namespace Vish_Tech_Ecom.Infra.Abstraction
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task<T> GetByIdAsync(int Id);
        Task<IReadOnlyList<T>> GetAllListAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T,bool>> filter= null,
                                        Func<IQueryable<T>,IOrderedQueryable<T>> orderby = null,
                                        string includeProperties="", int first=0, int offset=0);
    }
}
