using JWTAPI.WebApi.Models;

namespace JWTAPI.WebApi.Interface
{
    public interface IProducts
    {
        public List<Product>  GetProducts();

        public Product GetProductDetails(int id);

        public void AddProduct(Product employee);

        public void UpdateProduct(Product employee);

        public Product DeleteProduct(int id);

        public bool CheckProduct(int id);
    }
}
