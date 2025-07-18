using OrderAPI.Application.Interfaces;
using OrderAPI.Domain;
using System.Text.Json;

namespace OrderAPI.Application.UseCases.ProductUseCase
{
    public class GetAllProductsUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICachingService _cachingService;
        public GetAllProductsUseCase(IProductRepository productRepository, ICachingService cachingService)
        {

            _productRepository = productRepository;
            _cachingService = cachingService;
        }

        public async Task<IEnumerable<Product>> ExecuteAsync()
        {
            string cacheKey = "AllProducts";
            var cachedOrders = await _cachingService.GetStringAsync(cacheKey);
            if (cachedOrders != null)
            {
                return JsonSerializer.Deserialize<IEnumerable<Product>>(cachedOrders)!;
            }

            var products = (await _productRepository.GetAllAsync()).ToList();

            await _cachingService.SetStringAsync(
                cacheKey,
                JsonSerializer.Serialize(products),
                TimeSpan.FromHours(1)
            );

            return products;
        }
    }
}
