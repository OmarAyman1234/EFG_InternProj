using OrderAPI.Domain;

namespace OrderAPI.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddProduct(Product product);
        Task SaveChangesAsync();
    }
}
