using Microsoft.EntityFrameworkCore;

namespace AmbienceScoring.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}
}