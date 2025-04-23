using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.Models.Repositories;

namespace PieShop.Components;

public class CategoryMenu : ViewComponent
{
    private readonly ICategoryRepository _categoryRepository;
    public IEnumerable<Category> Categories { get; set; }

    public CategoryMenu(ICategoryRepository categoryRepository, IEnumerable<Category> categories)
    {
        _categoryRepository = categoryRepository;
        Categories = categories;
    }
    
    public IViewComponentResult Invoke()
    {
        var categories = _categoryRepository.GetCategories();
        Categories = categories;
       
        return View(this);
    }
}