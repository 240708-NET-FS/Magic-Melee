namespace MagicMelee.Models;

public class Login
{
    public int LoginId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    
    public int UserId { get; set; }

    public User User {get; set;}
    

}