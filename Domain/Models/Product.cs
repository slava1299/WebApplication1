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

        private Product(Guid id, string name, string description, decimal price, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CreatedAt = createdAt;
        }

        // Вместо Guid можно использовать long
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }
        public DateTime CreatedAt { get; }

        public static (Product Product, string Error) Create(Guid id, string name, string description, decimal price, DateTime createdAt)
        {
            var product = new Product(id, name, description, price, createdAt); 
            var error = string.Empty;
            if (price < 0)
            {
                error = "Цена не может быть отрицательной";
            }
            return (product, error);

        }
            
    }
}