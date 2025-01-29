using Microsoft.AspNetCore.Mvc;
using PieShop.Models.Repositories;
using PieShop.ViewModels;

namespace PieShop.Controllers;

public class ShoppingCartController : Controller
{

    private readonly IPieRepository _pieRepository;
    private readonly IShoppingCart _shoppingCart;
    
    public ShoppingCartController(IPieRepository pieRepository, IShoppingCart shoppingCart)
    {
        _pieRepository = pieRepository;
        _shoppingCart = shoppingCart;
    }
    public IActionResult Index()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;

        var shoppingCartViewModel = new ShoppingCartViewModel(
            _shoppingCart, _shoppingCart.GetShoppingCartTotal());

        return View(shoppingCartViewModel);
    }

    public RedirectToActionResult AddToShppingCart(int pieId)
    {
        var selectedPie = _pieRepository.GetPieById(pieId);
        _shoppingCart.AddToCart(selectedPie);
        return RedirectToAction("Index");
    }
    
    public RedirectToActionResult RemoveFromShoppingCart(int pieId)
    {
        var selectedPie = _pieRepository.GetPieById(pieId);
        _shoppingCart.RemoveFromCart(selectedPie);

        return RedirectToAction("Index");
    }
}