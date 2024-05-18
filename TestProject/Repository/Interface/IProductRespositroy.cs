using TestProject.Model;

namespace TestProject.Repository.Interface
{
    public interface IProductRespositroy
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
