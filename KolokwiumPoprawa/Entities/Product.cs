using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumPoprawa.Entities;

[Table("Product")]
[PrimaryKey(nameof(ProductId))]
public class Product
{
    [Column("ID")]
    public int ProductId { get; set; }
        
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    
    [Precision(10, 2)]
    public decimal Price { get; set; }
    
    public virtual ICollection<ProductDelivery> ProductDeliveries { get; set; } = null!;
}