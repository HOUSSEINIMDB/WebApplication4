using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Model;

public class GameItem
{
    [Key] 
    public String SerialNumber { get; set; }
    public int? GameId { get; set; }
    public int? CartId { get; set; }
    // public Game Game { get; set; }
    // public Cart? Cart { get; set; }
}