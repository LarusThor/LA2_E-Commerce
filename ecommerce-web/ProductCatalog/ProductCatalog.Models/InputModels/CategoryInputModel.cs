using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Models.InputModels;

public class CategoryInputModel
{
    [Required]
    [MinLength(3)]
    public string name { get; set; }
    [Required]
    [MinLength(10)]
    public string description { get; set; }
}

