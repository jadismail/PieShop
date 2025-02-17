using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.Models.Repositories;
using PieShop.ViewModels;

namespace PieShop.Controllers;

public class PieController : Controller
{
    private readonly IPieRepository _pieRepo;
    private readonly ICategoryRepository _categoryRepo;
    
    public PieController(IPieRepository pieRepo, ICategoryRepository categoryRepo)
    {
        _pieRepo = pieRepo;
        _categoryRepo = categoryRepo;
    }
    public IActionResult List()
    {
        var pies = _pieRepo.GetPies();
        var pieListViewModel = new PieListViewModel(pies, "Cheese Cake");
    
        return View(pieListViewModel);
    }

    // public IActionResult List(string category)
    // {
    //     IEnumerable<Pie> pies;
    //     string? currentCategory;
    //     
    //     if (string.IsNullOrEmpty(category))
    //     {
    //         pies = _pieRepo.GetPies().OrderBy(p => p.PieId);
    //         currentCategory = "All pies";
    //     }
    //     else
    //     { 
    //         pies = _pieRepo.GetPies().Where(p => p.Category)
    //     }
    //
    //     return View(new PieListViewModel(pies, currentCategory));
    //
    // }
    

    public IActionResult Details(int id)
    {
        var pie = _pieRepo.GetPieById(id);
        return View(pie);
        
    }
}