using Microsoft.EntityFrameworkCore;
using PC_BuyNET.Models;

namespace PC_BuyNET.Data.Services
{
    public class ItemService
    {
        private readonly PC_BuyNETDbContext _context;

        public ItemService(PC_BuyNETDbContext context)
        {
            _context = context;
        }
        public async Task<List<Item>> GetItemsAsync()
        {
            return await _context.Items
                .Include(i => i.Category)
                .Include(i => i.Reviews)
                .ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _context.Items
                .Include(i => i.Reviews)
                .FirstOrDefaultAsync(I => I.Id == id);
        }

        public async Task AddItemAsync(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = await GetItemByIdAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Item with ID {id} not found.");
            }
        }

        public async Task<decimal> GetAvarageRatingAsync(int id)
        {
            var item = await GetItemByIdAsync(id);

            if (item.Reviews.Count == 0) return 0;
            return (decimal)item.Reviews.Average(r => (int)r.Rating);
        }
    }
}