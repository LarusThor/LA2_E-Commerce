using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Models.InputModels;

public class ProductInputModel
{
    [Required]
    [MinLength(3)]
    public string name { get; set; }
    [Required]
    [MinLength(10)]
    public string description { get; set; }
    [Required]
    public decimal price { get; set; }
    [Required]
    public int categoryId { get; set; }
}