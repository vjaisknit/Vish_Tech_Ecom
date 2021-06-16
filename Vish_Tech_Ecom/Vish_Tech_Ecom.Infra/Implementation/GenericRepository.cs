using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _appDbContext.Set<T>().FindAsync(Id);
        }
    }
}
