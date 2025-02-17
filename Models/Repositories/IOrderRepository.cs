namespace PieShop.Models.Repositories;

public interface IOrderRepository
{
    void CreateOrder(Order order);
}