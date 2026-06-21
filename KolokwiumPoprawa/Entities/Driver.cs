using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace KolokwiumPoprawa.Entities;


[Table("Driver")]
[PrimaryKey(nameof(DriverId))]
public class Driver
{
    [Column("ID")]
    public int DriverId { get; set; }
    
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    
    [MaxLength(17)]
    public string LicenceNumber { get; set; } = null!;
    
    public virtual ICollection<Delivery> Deliveries { get; set; } = null!;

}