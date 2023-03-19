using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.DAL.Models;

public class Order
{
    public int Id { get; set; }
    [MaxLength] public string Number { get; set; } 
    [Column(TypeName = "timestamptz(7)")] public DateTime Date { get; set; }
    [ForeignKey("Provider")] public int ProviderId { get; set; }
}