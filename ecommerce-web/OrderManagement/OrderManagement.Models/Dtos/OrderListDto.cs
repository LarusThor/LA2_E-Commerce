using OrderManagement.Models.Entities;

namespace OrderManagement.Models.Dtos;

public class OrderListDto
{
    public int id { get; set; }
    public string emailAddress { get; set; }
    public decimal totalAmount { get; set; }
    public string status { get; set; }
    public DateTime? CreatedAt { get; set;}
}