
using Domain.DataAccess.Entites;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DomainDbContext _context;
        public ProductRepository(DomainDbContext context)
        {
            _context = context;
        }
        // получить все товары
        public async Task<List<Product>> GetProducts()
        {
            var productEntities = await _context.Products
                .AsNoTracking()
                .ToListAsync();
            var products = productEntities
                .Select(b => Product.Create(b.Id, b.Name, b.Description, b.Price, b.CreatedAt).Product)
                .ToList();
            return products;
        }
        // создать новый товар
        public async Task<Guid?> AddProduct(Product productAdd)
        {
            var isExcist = await _context.Products.FindAsync(productAdd); // поиск продукта в бд
            if (isExcist != null) // если нашел то вернуть null (или ex)
            { return null; }

            var product = new ProductEntity() { Id = productAdd.Id, Name = productAdd.Name, Description = productAdd.Description, Price = productAdd.Price };
            await _context.Products.AddAsync(product);
            return _context.SaveChanges() > 0 ? product.Id : null;

        }
        // получить товар по  Id
        public async Task<Product?> GetProductbyId(Guid id)
        {
            var productEntity = await _context.Products
                .AsNoTracking() // метод EFCore отключает отслеживание изменений для извлеченных объектов - оптимизация
                .FirstOrDefaultAsync(b => b.Id == id); // linq метод поиска по ключевому полю 
            if (productEntity != null)
            { // Метод Create возвращает кортеж 
                var (productbyId, _) = Product.Create(productEntity.Id, productEntity.Name, productEntity.Description, productEntity.Price, productEntity.CreatedAt);
                return productbyId;
            }
            else
            {
                return null;
            }
        }
        // обновить товар
        public async Task<Guid> UpdateProduct(Guid id, string name, string description, decimal price)
        {
            await _context.Products
                .Where(b => b.Id == id)  // поиск по заданному id
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Name, b => name)          // обновление всех property
                .SetProperty(b => b.Description, b => description)
                .SetProperty(b => b.Price, b => price));
            return id;
        }
        // удалить товар
        public async Task<Guid> DeleteProduct(Guid id)
        {
            await _context.Products
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }


    }


}
