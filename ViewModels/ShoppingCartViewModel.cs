using PieShop.Models;
using PieShop.Models.Repositories;

namespace PieShop.ViewModels;

public class ShoppingCartViewModel
{
    public IShoppingCart ShoppingCart { get; set; }
    public decimal ShoppingCartTotal { get; set; }

    public ShoppingCartViewModel(IShoppingCart shoppingCart, decimal shoppingCartTotal)
    {
        ShoppingCart = shoppingCart;
        ShoppingCartTotal = shoppingCartTotal;
    }
}