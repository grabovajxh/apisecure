using JWTAPI.WebApi.Interface;
using JWTAPI.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTAPI.WebApi.Controllers
{
    [Authorize]
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProducts _IProduct;

        public ProductController(IProducts IProduct)
        {
            _IProduct = IProduct;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await Task.FromResult(_IProduct.GetProducts());
        }

        // GET api/product/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var products = await Task.FromResult(_IProduct.GetProductDetails(id));
            if (products == null)
            {
                return NotFound();
            }
            return products;
        }

        // POST api/product
        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            _IProduct.AddProduct(product);
          
            return await Task.FromResult(product);
        }

        // PUT api/product/1
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(int id, Product product)
        {
            if (id != product.ProductID)
            {
                return BadRequest();
            }
            try
            {
                _IProduct.UpdateProduct(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(product);
        }

        // DELETE api/product/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            var employee = _IProduct.DeleteProduct(id);
            return await Task.FromResult(employee);
        }

        private bool ProductExists(int id)
        {
            return _IProduct.CheckProduct(id);
        }
    }
}
