using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product
    {

        private Product(Guid id, string name, string description, decimal price, DateTime createdAt, Guid categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CreatedAt = createdAt;
            CategoryId = categoryId;
        }

        // Вместо Guid можно использовать long
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }
        public DateTime CreatedAt { get; }

        public Guid CategoryId { get; }

        public static (Product Product, string Error) Create(Guid id, string name, string description, decimal price, DateTime createdAt, Guid categoryId)
        {
            var product = new Product(id, name, description, price, createdAt, categoryId); 
            var error = string.Empty;
            if (price < 0)
            {
                error = "Цена не может быть отрицательной";
            }
            return (product, error);

        }
        public virtual Category Category { get; private set; }

        // Промежуточная коллекция OrderItems
        public virtual ICollection<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();
    }
}