namespace PieShop.Models.Repositories;

public interface ICategoryRepository
{
    IEnumerable<Category> GetCategories();
}