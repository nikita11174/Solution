using System.ComponentModel.DataAnnotations;

namespace Solution.DAL.Models;

public class Provider
{
    public int Id { get; set; }
    [MaxLength] public string Name { get; set; }
}