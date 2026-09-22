using GymLog.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GymLog.API.Data;

public class GymLogDbContext:DbContext
{
    public GymLogDbContext(DbContextOptions<GymLogDbContext> dbContextOptions):base(dbContextOptions)
    {
        
    }

    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<WorkOutLog> WorkOutLogs { get; set; }
}