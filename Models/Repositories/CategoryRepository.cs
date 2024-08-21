using PieShop.Models.Context;

namespace PieShop.Models.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly PieContext _context;

    public CategoryRepository(PieContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Category> GetCategories()
    {
        return _context.Categories.OrderBy(c => c.CategoryName);
    }
}