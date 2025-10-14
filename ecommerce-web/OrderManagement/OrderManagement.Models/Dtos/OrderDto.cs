using OrderManagement.Models.Entities;

namespace OrderManagement.Models.Dtos;

public class OrderDto
{
    public int id { get; set; }
    
    public string emailAddress { get; set; }
    
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    
    public decimal Total { get; set; }
    
    public string status { get; set; }
    
    public ShippingAddress ShippingAddress { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}