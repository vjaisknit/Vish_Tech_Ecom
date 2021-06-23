using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vish_Tech_Ecom.Core.Data;
using Vish_Tech_Ecom.Core.Entities;
using Vish_Tech_Ecom.Infra.Abstraction;

namespace Vish_Tech_Ecom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _brandRepository;
        private readonly IGenericRepository<ProductType> _productType;

        public ProductController(IGenericRepository<Product> productRepository,
                                 IGenericRepository<ProductBrand> brandRepository,
                                 IGenericRepository<ProductType> productType)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _productType = productType;
        }
        
        [HttpGet]
        public async Task< ActionResult<List<Product>>> GetProducts()
        {

            var products = await _productRepository.GetAsync(includeProperties: "ProductBrand,ProductType");
           return Ok(products);
           
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {

            var productBrands = await _brandRepository.GetAllListAsync();
            return Ok(productBrands);

        }
        [HttpGet("productType")]
        public async Task<ActionResult<List<ProductType>>> GetProductType()
        {

            var productproductType = await _productType.GetAllListAsync();
            return Ok(productproductType);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetAsync(filter: a=> a.Id == id,includeProperties: "ProductBrand,ProductType");
            return Ok(product);
        }
    }
}
