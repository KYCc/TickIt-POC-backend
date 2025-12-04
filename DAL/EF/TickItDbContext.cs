using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public class TickItDbContext : DbContext
{
    public TickItDbContext(DbContextOptions<TickItDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Business> Businesses { get; set; }
    public DbSet<TimeEntry> TimeEntries { get; set; }
    public DbSet<EditLog> EditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}