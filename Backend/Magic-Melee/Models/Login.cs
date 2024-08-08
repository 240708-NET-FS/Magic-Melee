using System.ComponentModel.DataAnnotations;

namespace MagicMelee.Models;

public class Login
{
    [Key]
    public int LoginId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    
    public int UserId { get; set; }

    public User User {get; set;}
    

}