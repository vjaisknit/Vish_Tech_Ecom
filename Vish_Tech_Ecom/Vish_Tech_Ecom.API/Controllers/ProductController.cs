using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vish_Tech_Ecom.Core.Data;
using Vish_Tech_Ecom.Core.Entities;

namespace Vish_Tech_Ecom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
           // return _appDbContext.Products.ToList();
           return NoContent();
        }

        [Route("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            return _appDbContext.Products.FirstOrDefault(a => a.Id == id);
        }
    }
}
