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
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        [HttpGet]
        public async Task< ActionResult<List<Product>>> GetProducts()
        {

            var products = await _productRepository.GetProductListAsync();
           return Ok(products);
           
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {

            var productBrands = await _productRepository.GetProductBrandListAsync();
            return Ok(productBrands);

        }
        [HttpGet("productType")]
        public async Task<ActionResult<List<ProductType>>> GetProductType()
        {

            var productproductType = await _productRepository.GetProductTypeListAsync();
            return Ok(productproductType);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetSingleProductAsync(id);
            return Ok(product);
        }
    }
}
