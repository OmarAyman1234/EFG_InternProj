using OrderAPI.Domain;

namespace OrderAPI.Application.UseCases.ProductUseCase
{
    public class ProductService
    {
        private readonly GetAllProductsUseCase _getAllProducts;

        public ProductService(GetAllProductsUseCase getAllProducts)
        {
            _getAllProducts = getAllProducts;
        }

        public Task<IEnumerable<Product>> GetAllAsync() => _getAllProducts.ExecuteAsync();
    }
}
