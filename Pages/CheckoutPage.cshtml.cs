using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PieShop.Models;
using PieShop.Models.Repositories;

namespace PieShop.Pages;

public class CheckoutPage : PageModel
{
    [BindProperty]
    public Order? Order { get; set; }
    
    private readonly IOrderRepository _orderRepository;
    private readonly IShoppingCart _shoppingCart;

    public CheckoutPage(IOrderRepository orderRepository, IShoppingCart shoppingCart)
    {
        _orderRepository = orderRepository;
        _shoppingCart = shoppingCart;
    }
    
    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;

        if (_shoppingCart.ShoppingCartItems.Count == 0)
        {
            ModelState.AddModelError("", "Your cart is empty, add some pies first");
        }

        if (ModelState.IsValid)
        {
            if (Order != null) _orderRepository.CreateOrder(Order);
            _shoppingCart.ClearCart();
            return RedirectToPage("CheckoutCompletePage");
        }

        return Page();
    }
}