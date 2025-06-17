using Microsoft.EntityFrameworkCore;
using PC_BuyNET.Models;

namespace PC_BuyNET.Data.Services
{
    public class CategoryService
    {
        private readonly PC_BuyNETDbContext _context;

        public CategoryService(PC_BuyNETDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories
                .ToListAsync();
        }
    }
}