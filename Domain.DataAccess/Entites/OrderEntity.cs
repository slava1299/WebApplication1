using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataAccess.Entites
{
    public class OrderEntity
    {
        public Guid Id { get; }
        public string CustomerName { get; } = string.Empty;
        public string Address { get; } = string.Empty;
        public DateTime OrderDate { get; }
        public string Status { get; } = string.Empty;
    }
}
