using OrderManagement.Models.Dtos;
using OrderManagement.Models.Entities;
using OrderManagement.Models.InputModels;

namespace OrderManagement.Repositories.Interfaces;

public interface IOrdersRepository
{
    public OrderDto getOrderById(int id);


    public IEnumerable<OrderListDto> getAllOrders();

    public IEnumerable<OrderSummaryDto> getOrderForUser(string username);
    
    public Task<bool> CreateOrder(OrderInputModel order);
}