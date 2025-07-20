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
            try
            {
                var cachedOrders = await _cachingService.GetStringAsync(cacheKey);
                if (cachedOrders != null)
                {
                    return JsonSerializer.Deserialize<IEnumerable<Product>>(cachedOrders)!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in getting products cache: {ex.Message}");
            }

            var products = (await _productRepository.GetAllAsync()).ToList();

            try
            {
                await _cachingService.SetStringAsync(
                    cacheKey,
                    JsonSerializer.Serialize(products),
                    TimeSpan.FromHours(1)
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in setting products cache: {ex.Message}");
            }

            return products;
        }
    }
}
