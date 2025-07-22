using OrderAPI.Domain;
using OrderSharedContent;

namespace OrderAPI.Application.UseCases.ProductUseCase
{
    public class ProductService
    {
        private readonly GetAllProductsUseCase _getAllProducts;
        private readonly AddProductUseCase _addProductUseCase;

        public ProductService(GetAllProductsUseCase getAllProducts, AddProductUseCase addProductUseCase)
        {
            _getAllProducts = getAllProducts;
            _addProductUseCase = addProductUseCase;
        }

        public Task<IEnumerable<Product>> GetAllAsync() => _getAllProducts.ExecuteAsync();
        public Task<Product> AddProduct(AddProductRequest p) => _addProductUseCase.ExecuteAsync(p);
    }
}
