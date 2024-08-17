using Microsoft.AspNetCore.Mvc;
using PieShop.Models.Repositories;

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
    public IActionResult Index()
    {
        var pies = _pieRepo.GetPies();
        return View(pies);
    }
}