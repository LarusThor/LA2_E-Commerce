namespace OrderManagement.Models.InputModels;

public class OrderInputModel
{
    public string EmailAddress { get; set; }
    public List<OrderItemInputModel> Items { get; set; }
    public ShippingAddressInputModel ShippingAddress { get; set; }
}