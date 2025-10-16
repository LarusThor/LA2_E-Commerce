namespace ProductCatalog.Models.Entities;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    public string name { get; set; }
    
    public string description { get; set; }
}