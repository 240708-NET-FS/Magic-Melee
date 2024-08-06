using MagicMelee.Models;
using Microsoft.EntityFrameworkCore;
namespace MagicMelee.Data;

public class MagicMeleeContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet<DndCharacter> DndCharacters { get; set; }
    public DbSet<Spell> Spells { get; set; }
    public DbSet<CharacterSpell> CharacterSpells { get; set; }
    public DbSet<CharacterRace> CharacterRaces { get; set; }
    public DbSet<CharacterClass> CharacterClasses { get; set; }
    public DbSet<AbilityScoreArr> AbilityScoreArr { get; set; }
    public DbSet<Skills> Skills { get; set; }

    public MagicMeleeContext(DbContextOptions<MagicMeleeContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure many-to-many relationship between DndCharacter, CharacterSpell, and Spell.
        modelBuilder.Entity<CharacterSpell>()
            .HasKey(cs => new { cs.CharacterId, cs.SpellId });

        modelBuilder.Entity<CharacterSpell>()
            .HasOne(cs => cs.DndCharacter)
            .WithMany(dc => dc.CharacterSpells)
            .HasForeignKey(cs => cs.CharacterId);

        modelBuilder.Entity<CharacterSpell>()
            .HasOne(cs => cs.Spell)
            .WithMany(s => s.CharacterSpells)
            .HasForeignKey(cs => cs.SpellId);

        // Configure one-to-many relationship between CharacterRace and DndCharacter
        modelBuilder.Entity<DndCharacter>()
            .HasOne(dc => dc.CharacterRace)
            .WithOne(cr => cr.DndCharacter)
            .HasForeignKey<DndCharacter>(dc => dc.CharacterRaceId);
            
        // Configure one-to-many relationship between CharacterClass and DndCharacter
        modelBuilder.Entity<DndCharacter>()
            .HasOne(dc => dc.CharacterClass)
            .WithOne(cc => cc.DndCharacter)
            .HasForeignKey<DndCharacter>(dc => dc.CharacterClassId);

        // Configure one-to-one relationship between DndCharacter and AbilityScoreArr
        modelBuilder.Entity<DndCharacter>()
            .HasOne(dc => dc.AbilityScoreArr)
            .WithOne(asa => asa.DndCharacter)
            .HasForeignKey<DndCharacter>(dc => dc.AbilityScoreArrId);
        
        // One-to-One relationships for Skills
        modelBuilder.Entity<DndCharacter>()
            .HasOne(dc => dc.Skills)
            .WithOne(s => s.DndCharacter)
            .HasForeignKey<DndCharacter>(dc => dc.SkillsId);
    }

    internal async Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}
