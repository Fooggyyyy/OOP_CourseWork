using OOP_CourseWork.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OOP_CourseWork.DataBase.ADO.Repositories
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<int> AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task<IEnumerable<Product>> GetProductsSortedAsync(string sortBy);
        Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
        Task<byte[]> GetProductImageAsync(int id);
        Task UpdateProductImageAsync(int id, byte[] imageData);
    }
} 