namespace ProductCatalog.Models.Entities;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    public string name { get; set; }
    
    public string description { get; set; }
    
    public decimal price { get; set; }
    
    public int categoryId { get; set; }
}