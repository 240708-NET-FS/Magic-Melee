using MagicMelee.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



namespace MagicMelee.Data
{
    public class MagicMeleeContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Login> Logins { get; set; }
        public DbSet<DndCharacter> DndCharacters { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<CharacterSpell> CharacterSpells { get; set; }
        public DbSet<CharacterRace> CharacterRaces { get; set; }
        public DbSet<CharacterClass> CharacterClasses { get; set; }
        public DbSet<AbilityScoreArr> AbilityScoreArrs { get; set; }
        public DbSet<Skills> Skills { get; set; }

        public MagicMeleeContext(DbContextOptions<MagicMeleeContext> options) : base(options) {}



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

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

            // Configure one-to-one relationships
            modelBuilder.Entity<DndCharacter>()
                .HasOne(dc => dc.CharacterRace)
                .WithOne(cr => cr.DndCharacter)
                .HasForeignKey<DndCharacter>(dc => dc.CharacterRaceId);

            modelBuilder.Entity<DndCharacter>()
                .HasOne(dc => dc.CharacterClass)
                .WithOne(cc => cc.DndCharacter)
                .HasForeignKey<DndCharacter>(dc => dc.CharacterClassId);

            modelBuilder.Entity<DndCharacter>()
                .HasOne(dc => dc.AbilityScoreArr)
                .WithOne(asa => asa.DndCharacter)
                .HasForeignKey<DndCharacter>(dc => dc.AbilityScoreArrId);

            modelBuilder.Entity<DndCharacter>()
                .HasOne(dc => dc.Skills)
                .WithOne(s => s.DndCharacter)
                .HasForeignKey<DndCharacter>(dc => dc.SkillsId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Login)
                .WithOne (l => l.User)
                .HasForeignKey<Login>(l => l.UserId);
        }
    }
}