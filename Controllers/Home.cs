using Microsoft.AspNetCore.Mvc;
using PieShop.Models.Context;
using PieShop.Models.Repositories;
using PieShop.ViewModels;

namespace PieShop.Controllers;

public class Home : Controller
{
    private IPieRepository _pieRepository;
    
    
    public Home(IPieRepository pieRepository)
    {
        _pieRepository = pieRepository;
    }

    public IActionResult Index()
    {
        var piesOfTheWeek = _pieRepository.GetPiesOfTheWeek();
        var homeViewModel = new HomeViewModel(piesOfTheWeek);

        return View(homeViewModel);
    }
}