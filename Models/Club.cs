using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TestDemo.Models;

[Table("footballclubs")]
public class Club
{
    [Column("id")]
    public int Id { get; set; }
    [Key][Column("footballclub")]
    public string Name { get; set; }
    [Column("league")]
    public string League { get; set; }
    public List<Player> Players { get; set; } = new List<Player>();
}