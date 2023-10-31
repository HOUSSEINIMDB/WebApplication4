using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Model;

public class Cart
{
    [Key]
    public int CartId { get; set;}
    // public int TestNumber { get; set; }
    public ICollection<GameItem> CartItems { get; set; } = new List<GameItem>();
}