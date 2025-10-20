using Microsoft.EntityFrameworkCore;
using OrderManagement.Models.Dtos;
using OrderManagement.Models.Entities;
using OrderManagement.Models.InputModels;
using OrderManagement.Repositories.Data;
using OrderManagement.Repositories.Interfaces;
using System.Net.Http.Json;
using OrderManagement.Models.Dtos;
using OrderManagement.Models.Entities;
using OrderManagement.Models.InputModels;
using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Repositories.Implementations;

public class OrdersRepository : IOrdersRepository
{
    private readonly OrderManagementDbContext _dbContext;
    private readonly HttpClient _httpClient;

    public OrdersRepository(OrderManagementDbContext dbContext, HttpClient httpClient)
    {
        _dbContext = dbContext;
        _httpClient = httpClient;
    }

    public OrderDto getOrderById(int id)
    {
        var order = _dbContext.Orders
            .Include(o => o.Items)                 
            .Include(o => o.shippingAddress)
            .FirstOrDefault(o => o.id == id);

        if (order == null)
            return null;

        return new OrderDto
        {
            id = order.id,
            emailAddress = order.emailAddress,
            totalAmount = order.totalAmount,
            status = order.status,
            shippingAddress = new ShippingAddress
            {
                Street = order.shippingAddress.Street,
                City = order.shippingAddress.City,
                State = order.shippingAddress.State,
                ZipCode = order.shippingAddress.ZipCode,
                Country = order.shippingAddress.Country
            },
            Items = order.Items.Select(i => new OrderByIdDto
            {
                productId = i.productId,
                productName = i.productName,
                quantity = i.quantity,
                unitPrice = i.unitPrice,
            }).ToList(),
            CreatedAt = order.CreatedAt,
            UpdatedAt = order.UpdatedAt
        };
    }



    public IEnumerable<OrderListDto> getAllOrders()
    {
        var query = _dbContext.Orders
            .AsNoTracking() 
            .Select(o => new OrderListDto()
            {
                id = o.id,
                emailAddress = o.emailAddress,
                totalAmount = o.totalAmount,
                status = o.status,
                CreatedAt = o.CreatedAt,
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
            Items = new List<OrderItem>(),
            CreatedAt = DateTime.UtcNow,
            status = "Pending"
        };
        
        foreach (var item in orderInput.Items)
        {
            var productResponse = await _httpClient.GetAsync($"http://gatewayapi:8080/api/products/{item.ProductId}");

            if (!productResponse.IsSuccessStatusCode)
                throw new Exception($"Could not retrieve product {item.ProductId}");

            var product = await productResponse.Content.ReadFromJsonAsync<ProductDto>();

            if (product == null)
                throw new Exception($"Product {item.ProductId} not found or invalid response.");

            order.Items.Add(new OrderItem
            {
                productId = item.ProductId,
                productName = product.Name,
                quantity = item.Quantity,
                unitPrice = product.Price,
                Order = order
            });
        }
        
        order.totalAmount = order.Items.Sum(i => i.unitPrice * i.quantity);

        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();

        return true;
    }

}