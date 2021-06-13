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
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandListAsync()
        {
            return await _appDbContext.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductListAsync()
        {
           return await _appDbContext.Products
                .Include(a=> a.ProductType)
                .Include(a=> a.ProductBrand)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypeListAsync()
        {
            return await _appDbContext.ProductTypes.ToListAsync();
        }

        public async Task<Product> GetSingleProductAsync(int Id)
        {
            return await _appDbContext.Products
                .Include(a => a.ProductType)
                .Include(a => a.ProductBrand)
                .FirstOrDefaultAsync(b=> b.Id == Id);
        }
    }
}
