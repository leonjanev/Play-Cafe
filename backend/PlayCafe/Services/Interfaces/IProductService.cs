using PlayCafe.ViewModels.Cafe;

namespace PlayCafe.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetProductsBySubCategoryId(int subCategoryId);
        Task<Product> GetProductById(int id);
        Task<int> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
        Task<bool> UpdateProductAvailability(int id, bool isAvailable);
    }
} 