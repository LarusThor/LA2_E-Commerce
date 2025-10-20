using OrderManagement.Models.Dtos;
using OrderManagement.Models.Entities;
using OrderManagement.Models.InputModels;

namespace OrderManagement.Services.Interfaces;

public interface IOrdersService
{
    public OrderDto getOrderById(int id);
    public IEnumerable<OrderListDto> getAllOrders();
    public IEnumerable<OrderSummaryDto> getOrderForUser(string username);
    public Task<bool> CreateOrder(OrderInputModel order);
}