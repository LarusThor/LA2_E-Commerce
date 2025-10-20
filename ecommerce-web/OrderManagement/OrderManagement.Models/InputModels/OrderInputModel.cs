namespace OrderManagement.Models.InputModels;

public class OrderInputModel
{
    public string emailAddress { get; set; }
    public List<OrderItemInputModel> Items { get; set; }
    public ShippingAddressInputModel ShippingAddress { get; set; }
}