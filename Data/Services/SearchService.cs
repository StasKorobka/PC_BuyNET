using Microsoft.EntityFrameworkCore;
using PC_BuyNET.Models;

namespace PC_BuyNET.Data.Services
{
    public class SearchService
    {
        private readonly PC_BuyNETDbContext _context;
        private readonly ItemService _itemService;

        public SearchService(PC_BuyNETDbContext context, ItemService itemService)
        {
            _context = context;
            _itemService = itemService;
        }

        public async Task<List<Item>> SearchItemsAsync(string? searchQuerry, string? category,
            decimal? maxPrice, string priceOrder )
        {
            var items = _context.Items
                .Include(category => category.Category)
                .AsQueryable();


            if (!string.IsNullOrEmpty(searchQuerry))
            {
                items = items.Where(i =>
                        i.Name.ToLower().Contains(searchQuerry.ToLower()) ||
                        i.Description.ToLower().Contains(searchQuerry.ToLower()));

            }
            if (!string.IsNullOrWhiteSpace(category) &&
                category.ToLower() != "all")
                items = items.Where(i => i.Category.Name == category);

            if (maxPrice.HasValue)
                items = items.Where(i => i.Price <= maxPrice.Value);


            if (priceOrder == "Ascending")
            {
                items = items.OrderBy(i => i.Price);
            }
            else if (priceOrder == "Descending")
            {
                items = items.OrderByDescending(i => i.Price);
            }

            return await items.ToListAsync();
        }

    }
}
