using OrderManagement.Models.Dtos;
using OrderManagement.Models.Entities;
using OrderManagement.Models.InputModels;
using OrderManagement.Repositories.Data;
using OrderManagement.Repositories.Interfaces;

namespace OrderManagement.Repositories.Implementations;

public class OrdersRepository : IOrdersRepository
{
    private readonly OrderManagementDbContext _dbContext;

    public OrdersRepository(OrderManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public OrderDto getOrderById(int id)
    {
        var orders = _dbContext.Orders
            .FirstOrDefault(o => o.id == id);

        var order = new OrderDto()
        {
            id = orders.id,
            emailAddress = orders.emailAddress,
            Items = orders.Items,
            totalAmount = orders.totalAmount,
            status = orders.status,
            shippingAddress = orders.shippingAddress,
            CreatedAt = orders.CreatedAt,
            UpdatedAt = orders.UpdatedAt
        };
        return order;
    }

    public IEnumerable<OrderDto> getAllOrders()
    {
        var query = _dbContext.Orders
            .Select(o => new OrderDto()
            {
                id = o.id,
                emailAddress = o.emailAddress,
                Items = o.Items,
                totalAmount = o.totalAmount,
                status = o.status,
                shippingAddress = o.shippingAddress,
                CreatedAt = o.CreatedAt,
                UpdatedAt = o.UpdatedAt
            });
        return query.ToList();
    }

    public IEnumerable<OrderSummaryDto> getOrderForUser(string username)
    {
        return _dbContext.Orders
            .Where(o => o.emailAddress == username)
            .Select(o => new OrderSummaryDto
            {
                id = o.id,
                totalAmount = o.totalAmount,
                status = o.status,
                CreatedAt = o.CreatedAt,
            })
            .ToList();
    }
    
    public async Task<bool> CreateOrder(OrderInputModel orderInput)
    {
        var order = new Order
        {
            emailAddress = orderInput.emailAddress,
            shippingAddress = new ShippingAddress
            {
                Street = orderInput.ShippingAddress.Street,
                City = orderInput.ShippingAddress.City,
                State = orderInput.ShippingAddress.State,
                ZipCode = orderInput.ShippingAddress.ZipCode,
                Country = orderInput.ShippingAddress.Country
            },
            Items = orderInput.Items.Select(i => new OrderItem
            {
                productId = i.ProductId,
                quantity = i.Quantity
            }).ToList(),
            CreatedAt = DateTime.UtcNow,
            status = "Pending"
        };

        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();

        return true;
    }

}