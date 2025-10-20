using OrderManagement.Models.Entities;

namespace OrderManagement.Models.Dtos;

public class OrderAddItemDto
{
    public string emailAddress { get; set; }
    
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    
    public ShippingAddress shippingAddress { get; set; }
}