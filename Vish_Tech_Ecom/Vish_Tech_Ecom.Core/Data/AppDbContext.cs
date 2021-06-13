using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vish_Tech_Ecom.Core.Entities;

namespace Vish_Tech_Ecom.Core.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Product> Products { set; get; }
        public DbSet<ProductType> ProductTypes { set; get; }
        public DbSet<ProductBrand> ProductBrands { set; get; }

    }
}
