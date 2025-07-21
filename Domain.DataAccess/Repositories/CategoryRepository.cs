using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataAccess.Repositories
{
    public class CategoryRepository
    {

        private readonly DomainDbContext _context;
        public CategoryRepository(DomainDbContext context)
        {
            _context = context;
        }
        // получить все категории
        public async Task<List<Category>> GetCategoryes()
        {
            var CategoryEntities = await _context.Categories
                .AsNoTracking()
                .ToListAsync();
            var categories = CategoryEntities
                .Select(b => Category.Create(b.Id, b.Name, b.Description).Category)
                .ToList();
            return categories;
        }
    }
}
