using Microsoft.AspNetCore.Mvc;
using PC_BuyNET.Data.Services;
using PC_BuyNET.Models;

namespace PC_BuyNET.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Manage()
        {
            var categories = await _categoryService.GetCategoriesWithItemsAsync();

            return View(categories);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await _categoryService.AddCategory(category);

            return RedirectToAction("Manage", "Admin");
        }
    }
}