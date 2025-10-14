using OrderManagement.Models.Entities;

namespace OrderManagement.Models.Dtos;

public class OrderItemDto
{
    public int id { get; set; }
    
    public int productId { get; set; }
    
    public string productName { get; set; }
    
    public decimal unitPrice { get; set; }
    
    public int quantity { get; set; }
    
    public int orderId { get; set; }
    
    public Order Order { get; set; }
}