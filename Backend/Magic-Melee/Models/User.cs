using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace MagicMelee.Models;

public class User : IdentityUser<int>
{
    [NotMapped]
    public int UserId
    {
        get => Id;
        set => Id = value;
    }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public Login Login { get; set; }

    // Setting our one to many between users and characters
    // Initializing the list so that we can store returned characters within it later
    public List<DndCharacter> ExistingCharacters { get; set; } = new List<DndCharacter>();
}