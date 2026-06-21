using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace KolokwiumPoprawa.Entities;

[Table("Customer")]
[PrimaryKey(nameof(CustomerId))]
public class Customer
{
    [Column("ID")]
    public int CustomerId { get; set; }
    
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    
    [Column(TypeName = "datetime")] 
    public DateTime DateOfBirth { get; set; }
    
    public virtual ICollection<Delivery> Deliveries { get; set; } = null!;
}