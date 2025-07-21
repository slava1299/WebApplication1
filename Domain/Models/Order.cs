using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Order
    {
        public Guid Id { get; }
        public string CustomerName { get; }= string.Empty;
        public string Address { get; } = string.Empty;
        public DateTime OrderDate { get; }
        public string Status { get; } = string.Empty;    
    }

}
