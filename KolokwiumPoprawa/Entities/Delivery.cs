using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumPoprawa.Entities;
[Table("Delivery")]
[PrimaryKey(nameof(DeliveryId))]
public class Delivery
{
    [Column("ID")]
    public int DeliveryId { get; set; }

    [Column("CustomerId")] 
    public int CustomerId { get; set; }
    
    [Column("DriverId")]
    public int DriverId { get; set; }
    
    [Column(TypeName = "datetime")] 
    public DateTime Date { get; set; }
    
    [ForeignKey(nameof(CustomerId))]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey(nameof(DriverId))]
    public virtual Driver Driver { get; set; } = null!;
    
    public virtual ICollection<ProductDelivery> ProductDeliveries { get; set; } = null!;
}