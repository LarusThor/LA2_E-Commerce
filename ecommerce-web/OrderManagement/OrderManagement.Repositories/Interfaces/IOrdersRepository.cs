using OrderManagement.Models.Dtos;
using OrderManagement.Models.InputModels;

namespace OrderManagement.Repositories.Interfaces;

public interface IOrdersRepository
{
    public OrderDto getOrderById(int id);

    public IEnumerable<OrderDto> getAllOrders(OrderDto order);
    
    public IEnumerable <OrderDto> getOrderForUser(string username);

    public Task<bool> CreateOrder(OrderInputModel order);

    

}