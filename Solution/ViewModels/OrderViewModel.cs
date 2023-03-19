using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.ViewModels;

public class OrderViewModel
{
    public int Id { get; set; }
    [MaxLength] public string Number { get; set; } 
    [Column(TypeName = "timestamptz(7)")] public DateTime Date { get; set; }
    public int ProviderId { get; set; }
}