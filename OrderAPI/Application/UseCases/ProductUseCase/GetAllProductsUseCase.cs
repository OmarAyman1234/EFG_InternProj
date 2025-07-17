using OrderAPI.Application.Interfaces;
using OrderAPI.Domain;

namespace OrderAPI.Application.UseCases.ProductUseCase
{
    public class GetAllProductsUseCase
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> ExecuteAsync()
        {
            return await _productRepository.GetAllAsync();
        }
    }
}
