namespace MagicMelee.Models;

public class Login
{
    public int LoginId { get; set; }
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    
    public int UserId { get; set; }

    public User User {get; set;}
    

}