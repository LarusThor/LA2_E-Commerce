using OrderManagement.Models.Entities;

namespace OrderManagement.Models.Dtos;

public class OrderDto
{
    public int id { get; set; }
    
    public string emailAddress { get; set; }
    
    public ICollection<OrderByIdDto> Items { get; set; } = new List<OrderByIdDto>();
    
    public decimal totalAmount { get; set; }
    
    public string status { get; set; }
    
    public ShippingAddress shippingAddress { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}