using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TestDemo.Models;

[Table("footballplayers")]
public class Player
{
    [Key][Column("id")]
    public int Id { get; set; }
    [Column("firstname")]
    public string FirstName { get; set; }
    [Column("lastname")]
    public string LastName { get; set; }
    [Column("club")] [ForeignKey("club")]
    public string ClubName { get; set; }
     
    public Club Club { get; set; }
}