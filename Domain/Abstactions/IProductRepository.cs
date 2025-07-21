using Domain.Models;

namespace Domain.DataAccess.Repositories
{
    public interface IProductRepository
    {
        Task<Guid?> AddProduct(Product productAdd);
        Task<Guid> DeleteProduct(Guid id);
        Task<Product?> GetProductbyId(Guid id);
        Task<List<Product>> GetProducts();
        Task<Guid> UpdateProduct(Guid id, string name, string description, decimal price);
    }
}