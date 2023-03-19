using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.DAL.Models;

public class OrderItem
{
    public int Id { get; set; }
    [ForeignKey("Order")] public int OrderId { get; set; }
    [MaxLength] public string Name { get; set; }
    [Column(TypeName = "decimal(18,3)")] public decimal Quantity { get; set; }
    [MaxLength] public string Unit { get; set; }
}