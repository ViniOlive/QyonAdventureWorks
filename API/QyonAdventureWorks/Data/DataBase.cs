using Microsoft.EntityFrameworkCore;
using QyonAdventureWorks.Entitys;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<competidores> competidores { get; set; }
    public DbSet<historicocorrida> historicocorrida { get; set; }
    public DbSet<pistacorrida> pistacorrida { get; set; }

}
