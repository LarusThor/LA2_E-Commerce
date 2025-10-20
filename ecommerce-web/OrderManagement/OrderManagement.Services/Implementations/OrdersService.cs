namespace OrderManagement.Services.Implementations;

using OrderManagement.Models.Dtos;
using OrderManagement.Models.InputModels;
using OrderManagement.Repositories.Interfaces;
using OrderManagement.Services.Interfaces;

public class OrdersService : IOrderService
{
    private readonly IOrdersRepository _ordersRepository;

    public OrdersService(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    public OrderDto getOrderById(int id)
    {
        return _ordersRepository.getOrderById(id);
    }

    public IEnumerable<OrderDto> getAllOrders()
    {
        return _ordersRepository.getAllOrders();
    }

    public IEnumerable<OrderSummaryDto> getOrderForUser(string username)
    {
        return _ordersRepository.getOrderForUser(username);
    }

    public Task<bool> CreateOrder(OrderInputModel order)
    {   
        return _ordersRepository.CreateOrder(order);
    }
    
}



