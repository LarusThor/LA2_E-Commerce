namespace OrderManagement.Models.Dtos;

public class ShippingAddressDto
{
    public string street { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string zipCode { get; set; }
    public string country { get; set; }
}