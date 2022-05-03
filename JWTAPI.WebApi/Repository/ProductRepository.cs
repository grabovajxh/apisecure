using JWTAPI.WebApi.Interface;
using JWTAPI.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAPI.WebApi.Repository
{
    public class ProductRepository : IProducts
    {
        readonly DatabaseContext _dbContext = new();

        public ProductRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> GetProducts()
        {
            try
            {
                return _dbContext.Products.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Product GetProductDetails(int id)
        {
            try
            {
                Product? product = _dbContext.Products.Find(id);
                if (product != null)
                {
                    return product;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddProduct(Product product)
        {
            try
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                _dbContext.Entry(product).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Product DeleteProduct(int id)
        {
            try
            {
                Product? employee = _dbContext.Products.Find(id);

                if (employee != null)
                {
                    _dbContext.Products.Remove(employee);
                    _dbContext.SaveChanges();
                    return employee;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckProduct(int id)
        {
            return _dbContext.Products.Any(e => e.ProductID == id);
        }
    }
}
