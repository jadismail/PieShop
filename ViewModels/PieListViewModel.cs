using PieShop.Models;

namespace PieShop.ViewModels;

public class PieListViewModel
{
    public IEnumerable<Pie> Pies { get; set; }
    public string? CurrentCategory { get; set; }
    
    public PieListViewModel(IEnumerable<Pie> pies, string currentCategory)
    {
        Pies = pies;
        CurrentCategory = currentCategory;
    }
    
}