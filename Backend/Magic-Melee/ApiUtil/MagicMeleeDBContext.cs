using Microsoft.EntityFrameworkCore;
using Magic-Melee.ApiUtil.DTO;

namespace Magic-Melee.Data;

public class MagicMeleeDBContext : DBContext
{
    public MagicMeleeDBContext () {}
    public DBSet <>
    public DBSet <>

    protected override void OnConfiguring(DBContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("replace with connection strings")
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Add relationships
    }
}

