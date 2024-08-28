using Microsoft.AspNetCore.Mvc;
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

    public IActionResult Details(int id)
    {
        var pie = _pieRepo.GetPieById(id);
        return View(pie);
    }
}