using OrderManagement.Models.Entities;

namespace OrderManagement.Models.Dtos;

public class OrderSummaryDto
{
    public int id { get; set; }
    public decimal totalAmount { get; set; }
    public string status { get; set; }
    public DateTime? createdAt { get; set;}
}