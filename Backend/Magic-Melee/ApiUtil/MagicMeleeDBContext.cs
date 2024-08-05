using Microsoft.EntityFrameworkCore;
using Magic_Melee.ApiUtil.DTO;

namespace Magic_Melee.Data;

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

