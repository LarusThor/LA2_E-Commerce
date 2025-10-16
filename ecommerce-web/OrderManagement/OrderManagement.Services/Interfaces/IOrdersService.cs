using OrderManagement.Models.Dtos;
using OrderManagement.Models.InputModels;

namespace OrderManagement.Services.Interfaces;

public interface IOrderService
{
    public OrderDto getOrderById(int id);
    public IEnumerable<OrderDto> getAllOrders(OrderInputModel order);
    public IEnumerable<OrderDto> getOrderForUser(string username);
    public Task<bool> CreateOrder(OrderInputModel order);
}