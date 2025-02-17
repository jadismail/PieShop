using PieShop.Models.Context;

namespace PieShop.Models.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly PieContext _context;
    private readonly IShoppingCart _shoppingCart;

    public OrderRepository(PieContext context, IShoppingCart shoppingCart)
    {
        _context = context;
        _shoppingCart = shoppingCart;
    }
    
    public void CreateOrder(Order order)
    {
        order.OrderPlaced = DateTime.Now;
        order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

        var shoppingCartItems = _shoppingCart.GetShoppingCartItems();

        order.OrderDetails = new List<OrderDetail>();

        foreach (var shoppingCart in shoppingCartItems)
        {
            var orderDetail = new OrderDetail()
            {
                Amount = shoppingCart.Amount,
                PieId = shoppingCart.Pie.PieId,
                Price = shoppingCart.Pie.Price
            };
            order.OrderDetails.Add(orderDetail);
        }

        _context.Orders.Add(order);
        _context.SaveChanges();
    }
}