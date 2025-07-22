using OrderAPI.Application.Interfaces;
using OrderAPI.Domain;
using OrderSharedContent;

namespace OrderAPI.Application.UseCases.ProductUseCase
{
    public class AddProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public AddProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> ExecuteAsync(AddProductRequest addProductRequest)
        {
            var newProduct = new Product { Name = addProductRequest.Name, Description = addProductRequest.Description, Price = addProductRequest.Price };
            await _productRepository.AddProduct(newProduct);
            await _productRepository.SaveChangesAsync();
            return newProduct;
        }
    }
}
