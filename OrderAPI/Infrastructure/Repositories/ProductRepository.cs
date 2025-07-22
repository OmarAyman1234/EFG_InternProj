using Microsoft.EntityFrameworkCore;
using OrderAPI.Application.Interfaces;
using OrderAPI.Domain;
using OrderAPI.Infrastructure.Context;

namespace OrderAPI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrderContext _orderContext;
        public ProductRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _orderContext.Products.ToListAsync();
        }

        public async Task AddProduct(Product product)
        {
            await _orderContext.Products.AddAsync(product);
        }

        public async Task SaveChangesAsync()
        {
            await _orderContext.SaveChangesAsync();
        }
    }
}
