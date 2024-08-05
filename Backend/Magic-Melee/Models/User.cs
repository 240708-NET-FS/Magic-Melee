namespace MagicMelee.Models;

public class User
{
    public int UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public Login Login { get; set; }

    // Setting our one to many between users and characters
    // Initializing the list so that we can store returned characters within it later
    public List<DndCharacter> ExistingCharacters { get; set; } = new List<DndCharacter>();
}