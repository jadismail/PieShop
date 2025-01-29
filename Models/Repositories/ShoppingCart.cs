using Microsoft.EntityFrameworkCore;
using PieShop.Models.Context;

namespace PieShop.Models.Repositories;

public class ShoppingCart : IShoppingCart
{
    private readonly PieContext _context;
    public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;
    public string? ShoppingCartId { get; set; }
    
    public ShoppingCart(PieContext context)
    {
        _context = context;
    }

    public static ShoppingCart GetCart(IServiceProvider services)
    {
        var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
        var context = services.GetRequiredService<PieContext>();
        var cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
        session?.SetString("CartId", cartId);
        return new ShoppingCart(context) { ShoppingCartId = cartId };
    }
    
  
    public void AddToCart(Pie pie)
    {
        var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
            s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItem()
            {
                ShoppingCartId = ShoppingCartId,
                Pie = pie,
                Amount = 1
            };
            _context.ShoppingCartItems.Add(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Amount++;
        }
        _context.SaveChanges();
    }

    public int RemoveFromCart(Pie pie)
    {
        var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
            s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);
       
        if (shoppingCartItem is null) return 0;
        
        if(shoppingCartItem.Amount > 1)
           shoppingCartItem.Amount--;
        else
            _context.ShoppingCartItems.Remove(shoppingCartItem);
        
        _context.SaveChanges();
        return shoppingCartItem.Amount;
    }

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        return _context.ShoppingCartItems
                                    .Where(c => c.ShoppingCartId == ShoppingCartId)
                                    .Include(s => s.Pie)
                                    .ToList();
    }

    public void ClearCart()
    {
        var cartItems = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId);
        _context.ShoppingCartItems.RemoveRange(cartItems);
        _context.SaveChanges();
    }

    public decimal GetShoppingCartTotal()
    {
        var total = _context.ShoppingCartItems
            .Where(c => c.ShoppingCartId == ShoppingCartId)
            .Select(c => c.Pie.Price * c.Amount)
            .ToList()
            .Sum();
        return total;
    }
}