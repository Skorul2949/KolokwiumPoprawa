using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumPoprawa.Entities;

[Table("ProductDelivery")]
[PrimaryKey(nameof(ProductId),(nameof(DeliveryId)))]
public class ProductDelivery
{
    [Column("productid")]
    public int ProductId { get; set; }
    [Column("deliveryid")]
    public int DeliveryId { get; set; }

    public int Amount { get; set; }
    
    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; } = null!;
    
    [ForeignKey(nameof(DeliveryId))]
    public virtual Delivery Delivery { get; set; } = null!;
}