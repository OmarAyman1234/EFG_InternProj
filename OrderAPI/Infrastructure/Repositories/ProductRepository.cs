using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
    }
}
