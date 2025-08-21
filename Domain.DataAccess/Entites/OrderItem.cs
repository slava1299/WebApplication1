using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataAccess.Entites
{
    public class OrderItem
    {
        public Guid Id { get; }
        public int Quantity { get; }
        public decimal TotalPrice { get; }

        // Внешний ключ на заказ
        public Guid OrderId { get; }
        public virtual Order Order { get; private set; }

        // Внешний ключ на продукт
        public Guid ProductId { get; }
        public virtual Product Product { get; private set; }

        private OrderItem(Guid id, int quantity, decimal totalPrice, Guid orderId, Guid productId)
        {
            Id = id;
            Quantity = quantity;
            TotalPrice = totalPrice;
            OrderId = orderId;
            ProductId = productId;
        }

        public static (OrderItem Item, string Error) Create(Guid id, int quantity, decimal totalPrice, Guid orderId, Guid productId)
        {
            // Проверка данных
            if (quantity <= 0) return (null, "Количество должно быть положительным.");
            if (totalPrice <= 0) return (null, "Общая стоимость должна быть положительной.");

            var item = new OrderItem(id, quantity, totalPrice, orderId, productId);
            return (item, string.Empty);
        }
    }
}
