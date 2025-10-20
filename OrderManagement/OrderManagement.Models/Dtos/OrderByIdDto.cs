using OrderManagement.Models.Entities;

namespace OrderManagement.Models.Dtos;

public class OrderByIdDto
{
public int productId { get; set; }
    
public string productName { get; set; }
    
public decimal unitPrice { get; set; }
    
public int quantity { get; set; }

}