namespace MagicMelee.Data;

public class MagicMeleeContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet<DndCharacter> DndCharacters { get; set; }
    public DbSet<Spell> Spells { get; set; }
    public DbSet<CharacterSpell> CharacterSpells { get; set; }

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

        // Additional configurations
    }
}
