using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vish_Tech_Ecom.Core.Entities;

namespace Vish_Tech_Ecom.Infra.Abstraction
{
   public interface IProductRepository
    {
        Task<Product> GetSingleProductAsync(int Id);
        Task<IReadOnlyList<Product>> GetProductListAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypeListAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandListAsync();
    }
}
