using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Category
    {


        private Category(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;


        public static (Category Category, string Error) Create(Guid id, string name, string description)
        {
            var category = new Category(id, name, description);
            var error = string.Empty;
            return (category, error);

        }

    }
}
