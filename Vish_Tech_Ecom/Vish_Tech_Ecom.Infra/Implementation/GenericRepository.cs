using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vish_Tech_Ecom.Core.Data;
using Vish_Tech_Ecom.Core.Entities;
using Vish_Tech_Ecom.Infra.Abstraction;

namespace Vish_Tech_Ecom.Infra.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IReadOnlyList<T>> GetAllListAsync()
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> filter=null, 
                                                Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
                                                string includeProperties= "ProductType, ProductBrand", int first=0, int offset=0)
        {
            IQueryable<T> query = _appDbContext.Set<T>();
            if(filter!= null)
            {
                query = query.Where(filter);
            }

            if (offset > 0)
            {
                query = query.Skip(offset);
            }
            if (first > 0)
            {
                query = query.Take(first);
            }
            foreach(var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if(orderby != null)
            {
                return await orderby(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _appDbContext.Set<T>().FindAsync(Id);
        }
    }
}
