using AmbienceScoring.Models;
using Microsoft.EntityFrameworkCore;

namespace AmbienceScoring.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Parameter> Parameters { get; set; }
    public DbSet<Assesment> Assesments { get; set; }

}