using Day66.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Day66.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Location> Locations { get; set; }
    public DbSet<PlaneModel> PlaneModels { get; set; }
    public DbSet<Flight> Flights { get; set; }

    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}

